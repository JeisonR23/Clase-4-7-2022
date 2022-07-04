using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

public class Contexto : DbContext
{
    public DbSet<Compras> Compras {get; set;}
    public DbSet<Suplidores> Suplidores {get;set;}
    public DbSet<Productos> Productos {get; set;}

    public Contexto (DbContextOptions<Contexto>options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) 
    {
        modelBuilder.Entity<Productos>().HasData(
            new Productos
            {
                ProductoId = 1,
                Descripcion = "Huevos",
                Costo = 3,
                Precio = 7,
                Existencia =0
            },
             new Productos
            {
                ProductoId = 2,
                Descripcion = "Cebollas",
                Costo = 50,
                Precio = 85,
                Existencia =0
            },
             new Productos
            {
                ProductoId = 3,
                Descripcion = "Lechuga",
                Costo = 30,
                Precio = 50,
                Existencia =0
            }

        );


    }


  
    }

    

    
