//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GimnasioTitanes.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ventaSuplemento
    {
        public int id_ventaSuplemento { get; set; }
        public System.DateTime fecha_ventaSuplemto { get; set; }
        public string rut_usuario { get; set; }
        public int id_suplemento { get; set; }
        public int cantidad_suplemento { get; set; }
        public double venta_suplemento { get; set; }
    
        public virtual suplemento suplemento { get; set; }
        public virtual usuario usuario { get; set; }
    }
}
