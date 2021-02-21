using System;
using System.Collections.Generic;

#nullable disable

namespace ProWay.Models
{
    public partial class Lanchonete
    {
        public Lanchonete()
        {
            TurnoLanchonetes = new HashSet<TurnoLanchonete>();
        }

        public int LanchoneteId { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<TurnoLanchonete> TurnoLanchonetes { get; set; }
    }
}
