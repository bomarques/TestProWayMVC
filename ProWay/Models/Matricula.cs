using System;
using System.Collections.Generic;

#nullable disable

namespace ProWay.Models
{
    public partial class Matricula
    {
        public int MatriculaId { get; set; }
        public int? AlunoId { get; set; }
        public int? SalaId { get; set; }

        public virtual Aluno Aluno { get; set; }
        public virtual Sala Sala { get; set; }
    }
}
