using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class Integracao
    {
        public virtual string Distancia { get; set; }
        public virtual string Tempo { get; set; }
        public virtual string VelocidadeMedia { get; set; }
    }

}