using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    internal class RentaActivaDTO
    {
        public int ClienteFK { get; set; }
        public int CarritoFK { get; set; }
        public int VendedorFK { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFinalEstimada { get; set; }
        public DateTime HoraFinal { get; set; }
        public float TotalEstimado { get; set; }
        public float Total { get; set; }
    }
}

