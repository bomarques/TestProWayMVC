using System;
using System.Collections.Generic;

#nullable disable

namespace ProWay.Models
{
    public partial class TurnoCafeteria
    {
        public bool? Turno { get; set; }
        public int? IdAluno { get; set; }
        public int? IdCafeteria { get; set; }

        public virtual Aluno IdAlunoNavigation { get; set; }
        public virtual Cafeteria IdCafeteriaNavigation { get; set; }
    }
}
