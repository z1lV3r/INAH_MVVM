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
        protected ItemEditViewModel() { }
        public ItemEditViewModel(int id)
        {

            viewId = Guid.NewGuid();
            pieceDetailsDataService = new PieceDetailsDataService();
            piecesDataService = new PiecesDataService();

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
            var details = pieceDetailsDataService.Find(id);

            StockNumber = piece.TempId;
            CatalogNumber = piece.Identifiers.FirstOrDefault(pieceId => (pieceId.Type == "Catalog"))?.Value;
            RegistryNumber = piece.Identifiers.FirstOrDefault(pieceId => (pieceId.Type == "Registry"))?.Value;
            OtherNumber = piece.Identifiers.FirstOrDefault(pieceId => (pieceId.Type == "Other"))?.Value;
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
            Height = piece.Measures.FirstOrDefault(measure => (measure.Type == "Height"))?.Value ?? default;
            Width = piece.Measures.FirstOrDefault(measure => (measure.Type == "Width"))?.Value ?? default;
            Length = piece.Measures.FirstOrDefault(measure => (measure.Type == "Length"))?.Value ?? default;
            Diameter = piece.Measures.FirstOrDefault(measure => (measure.Type == "Diameter"))?.Value ?? default;
            Weight = piece.Measures.FirstOrDefault(measure => (measure.Type == "Weight"))?.Value ?? default;
        }

        private void SaveCommandExec(object obj)
        {
            piecesDataService.Upsert(new Pieces());
            pieceDetailsDataService.Upsert(new Piece_Details());
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
