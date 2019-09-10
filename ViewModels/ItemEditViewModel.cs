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

        protected ItemEditViewModel() { }
        public ItemEditViewModel(int  id, int userId) : base(id, userId)
        {
            this.userId = userId;

            viewId = Guid.NewGuid();

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

            if (CatalogNumber != default) identifiersService.Upsert(StockNumber, "Catalog", CatalogNumber);
            if (RegistryNumber != default) identifiersService.Upsert(StockNumber, "Registry", RegistryNumber);
            if (OtherNumber != default) identifiersService.Upsert(StockNumber, "Other", OtherNumber);

            if (Height > default(float)) measuresDataService.Upsert(StockNumber, "Height", Height);
            if (Width > default(float)) measuresDataService.Upsert(StockNumber, "Width", Width);
            if (Length > default(float)) measuresDataService.Upsert(StockNumber, "Length", Length);
            if (Diameter > default(float)) measuresDataService.Upsert(StockNumber, "Diameter", Diameter);
            if (Weight > default(float)) measuresDataService.Upsert(StockNumber, "Weight", Weight);

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
