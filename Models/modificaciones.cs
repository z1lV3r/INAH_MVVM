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
    
    public partial class modificaciones
    {
        public int Id_cambio { get; set; }
        public System.DateTime Fecha_de_cambio { get; set; }
        public int Id_persona { get; set; }
        public string Numero_de_inventario { get; set; }
        public string Campo { get; set; }
        public string Valor_anterior { get; set; }
        public string Valor_actual { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
    
        public virtual piezas piezas { get; set; }
    }
}