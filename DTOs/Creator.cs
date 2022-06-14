using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium2.DTOs
{
    public class Wykonawca
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public List<Track> Tracks { get; set; }
         
    }
}