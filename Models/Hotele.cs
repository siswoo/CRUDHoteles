using System;
using System.Collections.Generic;

namespace CRUDHoteles.Models
{
    public partial class Hotele
    {
        public int HotelId { get; set; }
        public string HotelName { get; set; } = null!;
        public string Categoria { get; set; } = null!;
        public float Precio { get; set; }
        public string Foto1 { get; set; } = null!;
        public string Foto2 { get; set; } = null!;
        public string Foto3 { get; set; } = null!;
    }
}
