using System.ComponentModel.DataAnnotations;
public class Productos
{
    [Key]
    public int ProductoId { get; set; }
    public String? Descripcion { get; set; }
    public double Costo { get; set; }
    public double Precio { get; set; }
    public double Existencia { get; set; }
}