using System;
using System.Collections.Generic;

#nullable disable

namespace ProWay.Models
{
    public partial class Cafeteria
    {
        public Cafeteria()
        {
            TurnoCafeteria = new HashSet<TurnoCafeteria>();
        }
        public int IdCafeteria { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<TurnoCafeteria> TurnoCafeteria { get; set; }
    }
}
