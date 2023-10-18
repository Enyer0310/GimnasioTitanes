using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GimnasioTitanes.Models
{
    public class LaVentaSuplemento
    {
        public int id { get; set; }
        public DateTime fecha { get; set; }
        public string rut { get; set; }
        public int idSuplemento { get; set; }
        public int cantidadSuplemento { get; set; }
        public int ventaSuplemento { get; set; }
    }
}