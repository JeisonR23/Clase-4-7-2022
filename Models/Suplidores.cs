using System.ComponentModel.DataAnnotations;

public class Suplidores
{

    [Key]
    public int suplidorId { get; set; }

    public string Nombre { get; set; }
 
}