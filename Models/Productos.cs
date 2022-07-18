using System.ComponentModel.DataAnnotations;
public class Productos
{
    [Key]
    public int ProductoId { get; set; }

    [Required(ErrorMessage = "Ingrese la descripcion del producto")]
    public String? Descripcion { get; set; }

    [Range(1, 1_000_000, ErrorMessage = "Ingrese el costo del producto")]
    public double Costo { get; set; }

    [Range(1, 1_000_000, ErrorMessage = "Ingrese el precio del producto")]

     public double Existencia { get; set; }
    public double Precio { get; set; }



}