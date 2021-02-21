using System;
using System.Collections.Generic;

#nullable disable

namespace ProWay.Models
{
    public partial class TurnoLanchonete
    {
        public int IdTurnoLanchonete { get; set; }
        public int? Turno { get; set; }
        public int? AlunoId { get; set; }
        public int? LanchoneteId { get; set; }

        public virtual Aluno Aluno { get; set; }
        public virtual Lanchonete Lanchonete { get; set; }
    }
}
