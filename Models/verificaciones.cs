//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace INAH.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class verificaciones
    {
        public string Id_verificacion { get; set; }
        public int Clave_de_museo { get; set; }
        public System.DateTime Fecha_de_inicio { get; set; }
        public System.DateTime Fecha_de_termino { get; set; }
        public string Ruta_acta { get; set; }
    
        public virtual museos museos { get; set; }
    }
}