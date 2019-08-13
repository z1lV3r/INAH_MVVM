using INAH.Commands;
using INAH.Services;
using INAH.ViewModels.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INAH.ViewModels
{
    public class ItemDetailViewModel : BaseItemOpWindowViewModel
    {
        private static Guid viewId;
        public override Guid ViewId { get { return viewId; } }

        public ItemDetailViewModel()
        {
            viewId = Guid.NewGuid();
            Title = "Detalle de elemento";
            CatalogNumber = "CatalogNumber example";
            RegistryNumber = "RegistryNumber example";
            OtherNumber = "OtherNumber example";
            CoveredPieces = 3;
            Type = "Type example";
            StockNumber = "StockNumber example";
            Subject = "Subject example";
            Author = "Author example";
            Period = "Period example";
            Culture = "Culture example";
            Origin = "Origin example";
            Shape = "Shape example";
            Inscriptions = "Inscriptions example";
            Description = "Description muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy muy larga";
            Remarks = "Remarks example";
            Collection = "Collection example";
            ConservationType = 2;
            Valuation = 100;
            RawMaterial = "RawMaterial example";
            ManufacturingTechnique = "ManufacturingTechnique example";
            DecorativeTechnique = "DecorativeTechnique example";
            Provenance = "Provenance example";
            AcquisitionMethod = "AcquisitionMethod example";
            Location = "Location example";

            Height = 20.5f;
            Width = 22.5f;
            Length = 20.5f;
            Diameter = 20.5f;
            Weight = 20.5f;
        }
    }
}
