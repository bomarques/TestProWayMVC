using System;
using System.Collections.Generic;

#nullable disable

namespace ProWay.Models
{
    public partial class Sala
    {
        public int IdSala { get; set; }
        public string Nome { get; set; }
        public int? Capacidade { get; set; }
    }
}
