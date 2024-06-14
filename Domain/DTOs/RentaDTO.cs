using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class RentaDTO
    {
        public int ClienteFK { get; set; }
        public int CarritoFK { get; set; }
        public int VendedorFK { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFinal { get; set; }
        public float Total { get; set; }
    }
}
