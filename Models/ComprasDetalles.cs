using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ComprasDetalles
    {
        [Key]
        public int DetalleId { get; set; }

        public int CompraId { get; set; }

        public int ProductoId { get; set; }

        
        [NotMapped]
        public string Descripcion { get; set; }

        public double Costo { get; set; }
        public double Precio { get; set; }
        public double Existencia { get; set; }
        
        public override string? ToString()
        {
            return $"Detalle # {DetalleId}, ProductoId= {ProductoId} , Costo = {Costo}, Precio={Precio},  Existencia ={Existencia} ";
        }
    }