using System.ComponentModel.DataAnnotations;

public class Suplidores
{

    [Key]
    public int suplidorId { get; set; }

    public string Nombre { get; set; }

    public string Direccion { get; set; }

    public string Telefono { get; set; }

    public string Email { get; set; }
    
}