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
    
    public partial class Piece_Details
    {
        public int TempId { get; set; }
        public Nullable<int> CoveredPieces { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Author { get; set; }
        public string Period { get; set; }
        public string Culture { get; set; }
        public string Origin { get; set; }
        public string Shape { get; set; }
        public string Remarks { get; set; }
        public string Collection { get; set; }
        public Nullable<int> ConservationType { get; set; }
        public Nullable<float> Valuation { get; set; }
        public string Inscriptions { get; set; }
        public string Provenance { get; set; }
        public string AcquisitionMethod { get; set; }
        public string RawMaterial { get; set; }
        public string ManufacturingTechnique { get; set; }
        public string DecorativeTechnique { get; set; }
        public string Location { get; set; }
    
        public virtual Pieces Pieces { get; set; }
    }
}
