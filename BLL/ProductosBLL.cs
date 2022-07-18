using Microsoft.EntityFrameworkCore;


public class ProductosBLL
{
    private Contexto _contexto;
    public ProductosBLL(Contexto contexto)
    {
        _contexto = contexto;
    }


     public bool Existe(int productoId)
    {
        return _contexto.Productos.Any(c => c.ProductoId == productoId);
    }

    public bool Guardar(Productos productos)
    {
        bool paso = false;

        if (!Existe(productos.ProductoId))
            paso = Insertar(productos);
        else
            paso = Modificar(productos);

        return paso;
    }

    private bool Insertar(Productos productos)
    {
        _contexto.Productos.Add(productos);
        var insertados = _contexto.SaveChanges();
        _contexto.Entry(productos).State = EntityState.Detached;
        return insertados > 0;
    }

    private bool Modificar(Productos productos)
    {   
        _contexto.Entry(productos).State = EntityState.Modified;

        var paso =  _contexto.SaveChanges() > 0;

        _contexto.Entry(productos).State = EntityState.Detached;

        return paso ;
    }

        public bool Eliminar(Productos productos)
    {
        _contexto.Entry(productos).State = EntityState.Deleted;
        _contexto.Database.ExecuteSqlRaw($"DELETE FROM ComprasDetalles WHERE ProductoId={productos.ProductoId};");
        bool paso = _contexto.SaveChanges() > 0;
        _contexto.Entry(productos).State = EntityState.Detached;

        return paso;
    }



    public List<Productos> BuscarP(int? productoId)
    {
            var buscado = _contexto.Productos
            .Where(p => p.ProductoId == productoId)
            .AsNoTracking()
            .ToList();
        return  buscado;
    }

     public Productos BuscarId(int? productoId)
    {
            var buscado = _contexto.Productos
            .Where(p => p.ProductoId == productoId)
            .AsNoTracking()
            .SingleOrDefault();
        return  buscado;
    }


    public Productos Buscar(int? productoId)
    {
        var producto = _contexto.Productos
            .Where(p => p.ProductoId == productoId)
            .AsNoTracking()
            .SingleOrDefault();

        return producto;
    }

    public List<Productos> GetList()
    {
        return _contexto.Productos.AsNoTracking().ToList();
    }
}

