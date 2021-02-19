using System;
using System.Collections.Generic;

#nullable disable

namespace ProWay.Models
{
    public partial class Sala
    {
        public Sala()
        {
            EtapaSalas = new HashSet<EtapaSala>();
        }

        public int IdSala { get; set; }
        public string Nome { get; set; }
        public int? Capacidade { get; set; }

        public virtual ICollection<EtapaSala> EtapaSalas { get; set; }
    }
}
