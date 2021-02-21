using System;
using System.Collections.Generic;

#nullable disable

namespace ProWay.Models
{
    public partial class Sala
    {
        public Sala()
        {
            Matriculas = new HashSet<Matricula>();
        }

        public int SalaId { get; set; }
        public string Nome { get; set; }
        public int? Capacidade { get; set; }

        public virtual ICollection<Matricula> Matriculas { get; set; }
    }
}
