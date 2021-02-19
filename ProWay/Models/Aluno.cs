using System;
using System.Collections.Generic;

#nullable disable

namespace ProWay.Models
{
    public partial class Aluno
    {
        public Aluno()
        {
            EtapaSalas = new HashSet<EtapaSala>();
            TurnoCafeteria = new HashSet<TurnoCafeteria>();
        }

        public int IdAluno { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }

        public virtual ICollection<EtapaSala> EtapaSalas { get; set; }
        public virtual ICollection<TurnoCafeteria> TurnoCafeteria { get; set; }
    }
}
