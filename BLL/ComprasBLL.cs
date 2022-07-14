using Microsoft.EntityFrameworkCore;

public class ComprasBLL
{
    private Contexto _contexto;
    public ComprasBLL(Contexto contexto)
    {
        _contexto = contexto;
    }

    public bool Existe(int compraId)
    {
        return _contexto.Compras.Any(c => c.CompraId == compraId);
    }

    public bool Guardar(Compras compra)
    {
        bool paso = false;

        if (!Existe(compra.CompraId))
            paso = Insertar(compra);
        else
            paso = Modificar(compra);

        return paso;
    }

    private bool Insertar(Compras compra)
    {
        _contexto.Compras.Add(compra);

        foreach (var item in compra.Detalle)
        {
            var producto = _contexto.Productos.Find(item.ProductoId);

            producto.Existencia += item.Cantidad;

        }

        var insertados = _contexto.SaveChanges();
        _contexto.Entry(compra).State = EntityState.Detached;
        return insertados > 0;
    }

    private bool Modificar(Compras compra)
    {   
        _contexto.Entry(compra).State = EntityState.Modified;

        var paso =  _contexto.SaveChanges() > 0;

        _contexto.Entry(compra).State = EntityState.Detached;

        return paso ;
    }

    public List<Compras> Buscar(DateTime fecha, DateTime fecha2)
    {

        var fechas = _contexto.Compras
         .Where(f => f.Fecha.Date == fecha.Date || f.Fecha.Date == fecha2.Date)
         .AsNoTracking().ToList();
        return fechas;
    }

     public bool Eliminar(Compras compras)
    {
        _contexto.Entry(compras).State = EntityState.Deleted;

        foreach (var item in compras.Detalle )
        {
            var productos = _contexto.Productos.Find(item.ProductoId);
            productos.Existencia -= item.Cantidad;
        }

        _contexto.Database.ExecuteSqlRaw($"DELETE FROM ComprasDetalles WHERE CompraId={compras.CompraId};");

        bool paso = _contexto.SaveChanges() > 0;
        _contexto.Entry(compras).State = EntityState.Detached;

        return paso;
    }

    public Compras BuscarP(int idCompras)
    {
        var compra = _contexto.Compras
        .Include(x => x.Detalle)
            .Where(c => c.CompraId == idCompras)
            .AsNoTracking()
            .SingleOrDefault();

        return compra;
    }

      public List<Compras> GetList()
    {
        return _contexto.Compras.AsNoTracking().ToList();
    }
}

