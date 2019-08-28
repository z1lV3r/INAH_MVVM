using INAH.Commands;
using INAH.Services;
using INAH.ViewModels.Abstracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INAH.Models;
using INAH.Services.DataServices;
using Microsoft.Win32;

namespace INAH.ViewModels
{
    public class ItemEditViewModel : BaseItemOpWindowViewModel
    {
        public static Guid viewId;
        public override Guid ViewId => viewId;

        public ObservableCollection<string> Types { get; set; }

        public ObservableCollection<string> ConservationTypes { get; set; }

        public RelayCommand SaveCommand { get; set; }
        public RelayCommand LinkImageCommand { get; set; }

        private PieceDetailsDataService pieceDetailsDataService;
        private PiecesDataService piecesDataService;
        private IdentifiersDataService identifiersService;
        private MeasuresDataService measuresDataService;
        protected ItemEditViewModel() { }
        public ItemEditViewModel(int id, int userId)
        {
            this.userId = userId;

            viewId = Guid.NewGuid();
            pieceDetailsDataService = new PieceDetailsDataService();
            piecesDataService = new PiecesDataService();
            identifiersService = new IdentifiersDataService();
            measuresDataService = new MeasuresDataService();

            Title = "Edición de elemento";

            Types = new ObservableCollection<string>
            {
                "Arqueológico","Histórico","Paleontológico","Etnográfico","Contemporáneo"
            };

            ConservationTypes = new ObservableCollection<string>
            {
                "No requiere intervencion", "Requiere intervencion", "Requiere intervencion urgente", "En riesgo"
            };

            LinkImageCommand = new RelayCommand(LinkImageCommandExec);
            SaveCommand = new RelayCommand(SaveCommandExec);

            var piece = piecesDataService.Find(id);
            var details = pieceDetailsDataService.Find(id)?? new Piece_Details();

            StockNumber = piece.TempId;
            CatalogNumber = identifiersService.GetIdentifier(id, "Catalog");
            RegistryNumber = identifiersService.GetIdentifier(id, "Registry");
            OtherNumber = identifiersService.GetIdentifier(id, "Other");
            CoveredPieces = details.CoveredPieces;
            Type = details.Type;
            Subject = piece.Subject;
            Author = details.Author;
            Period = details.Period;
            Culture = details.Culture;
            Origin = details.Origin;
            Shape = details.Shape;
            Inscriptions = details.Inscriptions;
            Description = details.Description;
            Remarks = details.Remarks;
            Collection = details.Collection;
            ConservationType = details.ConservationType;
            Valuation = details.Valuation;
            RawMaterial = details.RawMaterial;
            ManufacturingTechnique = details.ManufacturingTechnique;
            DecorativeTechnique = details.DecorativeTechnique;
            Provenance = details.Provenance;
            AcquisitionMethod = details.AcquisitionMethod;
            Location = details.Location;
            Height = measuresDataService.GetMeasure(id, "Height");
            Width = measuresDataService.GetMeasure(id, "Width");
            Length = measuresDataService.GetMeasure(id, "Length");
            Diameter = measuresDataService.GetMeasure(id, "Diameter");
            Weight = measuresDataService.GetMeasure(id, "Weight");
        }

        private void SaveCommandExec(object obj)
        {
            piecesDataService.Upsert(new Pieces()
            {
                Subject = Subject,
                TempId = StockNumber,
                CreatedBy = userId
            });
            pieceDetailsDataService.Upsert(new Piece_Details()
            {
                TempId = StockNumber,
                CoveredPieces = CoveredPieces,
                Type = Type,
                Author = Author,
                Period = Period,
                Culture = Culture,
                Origin = Origin,
                Shape = Shape,
                Inscriptions = Inscriptions,
                Description = Description,
                Remarks = Remarks,
                Collection = Collection,
                ConservationType = ConservationType,
                Valuation = Valuation,
                RawMaterial = RawMaterial,
                ManufacturingTechnique = ManufacturingTechnique,
                DecorativeTechnique = DecorativeTechnique,
                Provenance = Provenance,
                AcquisitionMethod = AcquisitionMethod,
                Location = Location
        });
            navigatorService.Close(ViewId);
        }

        private void LinkImageCommandExec(object obj)
        {
            var dlg = new OpenFileDialog
            {
                Filter = " Images |*.png;*.jpg;*.jpeg;| PNG Files (*.png) |*.png| JPEG Files (*.jpeg) |*.jpeg| JPG Files (*.jpg) |*.jpg"
            };

            var result = dlg.ShowDialog();

            if (result.HasValue && result.Value)
            {
                ImageSource = dlg.FileName;
            }
        }
    }
}
