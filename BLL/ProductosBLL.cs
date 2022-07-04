using Microsoft.EntityFrameworkCore;


public class ProductosBLL
{
    private Contexto _contexto;
    public ProductosBLL(Contexto contexto)
    {
        _contexto = contexto;
    }

    public Productos BuscarP(int productoId)
    {
        var producto = _contexto.Productos
            .Where(p => p.ProductoId == productoId)
            .AsNoTracking()
            .SingleOrDefault();

        return producto;
    }


    public Productos Buscar(int productoId)
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

