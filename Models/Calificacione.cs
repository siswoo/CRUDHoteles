using System;
using System.Collections.Generic;

namespace CRUDHoteles.Models
{
    public partial class Calificacione
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public int Calificacion { get; set; }
        public string Comentario { get; set; } = null!;
    }
}
