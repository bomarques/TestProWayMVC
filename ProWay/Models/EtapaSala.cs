using System;
using System.Collections.Generic;

#nullable disable

namespace ProWay.Models
{
    public partial class EtapaSala
    {
        public int IdEtapa { get; set; }
        public int? Etapa { get; set; }
        public int? IdAluno { get; set; }
        public int? IdSala { get; set; }

        public virtual Aluno IdAlunoNavigation { get; set; }
        public virtual Sala IdSalaNavigation { get; set; }
    }
}
