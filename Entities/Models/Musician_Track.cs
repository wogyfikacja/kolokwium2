using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium2.Entities.Models
{
    public class Musician_Track
    {
        public virtual Track Track { get; set; }
        public virtual Musician Musician { get; set; }
    }
}