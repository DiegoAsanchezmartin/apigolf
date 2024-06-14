using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class RentaActiva
    {
        [Key]
        public int RentaActivaID { get; set; }
        [ForeignKey("Cliente")]
        public int ClienteFK { get; set; }
        [ForeignKey("Cliente")]
        public int CarritoFK { get; set; }
        [ForeignKey("Vendedor")]
        public int VendedorFK { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFinalEstimada { get; set; }
        public DateTime HoraFinal {  get; set; }
        public float TotalEstimado { get; set; }
        public float Total { get; set; }
    }
}
