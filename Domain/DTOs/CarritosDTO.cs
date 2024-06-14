using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class CarritosDTO
    {
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public float PrecioHora { get; set; }
        public string IMGURL { get; set; }
        public bool Enrenta { get; set; }
    }
}
