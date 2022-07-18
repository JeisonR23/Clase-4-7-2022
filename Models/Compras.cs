using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Compras
{
    [Key]
    public int CompraId { get; set; }

    public DateTime Fecha { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "Ingrese el nombre del suplidor")]
    public string SuplidorId { get; set; }

   [Required(ErrorMessage = "Ingrese el el NCF")]
    public string Ncf { get; set; }


    public double Total { get; set; }

    [ForeignKey("CompraId")]
    public List<ComprasDetalles> Detalle { get; set; } = new List<ComprasDetalles>();

    public double TotalCompras
    {
        get { return Total + Total; }
    }

    public override string? ToString()
    {
        return $"Compra: Id={CompraId}, Fecha={Fecha},  SuplidorId ={SuplidorId}, Ncf = {Ncf}, Total={Total}, TotalCompras = {TotalCompras}";
    }
}