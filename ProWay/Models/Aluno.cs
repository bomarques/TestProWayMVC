﻿using System;
using System.Collections.Generic;

#nullable disable

namespace ProWay.Models
{
    public partial class Aluno
    {
        public Aluno()
        {
            Matriculas = new HashSet<Matricula>();
            TurnoLanchonetes = new HashSet<TurnoLanchonete>();
        }

        public int AlunoId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public int? Matricula { get; set; }

        public virtual ICollection<Matricula> Matriculas { get; set; }
        public virtual ICollection<TurnoLanchonete> TurnoLanchonetes { get; set; }
    }
}
