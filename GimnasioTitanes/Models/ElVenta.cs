using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GimnasioTitanes.Models
{
    public class ElVenta
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int precio { get; set; }
        public DateTime fecha { get; set; }
        public string rut { get; set; }
        public int id_planes { get; set; }
        public int cantidad { get; set; }
        public int valor { get; set; }
    }
}