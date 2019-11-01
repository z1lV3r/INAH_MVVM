using INAH.Commands;
using INAH.Services;
using INAH.ViewModels.Abstracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using INAH.Exceptions;
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

            ImageSource = Utils.GetImageSource(StockNumber);

            LinkImageCommand = new RelayCommand(LinkImageCommandExec);
            SaveCommand = new RelayCommand(SaveCommandExec);
        }

        private void SaveCommandExec(object obj)
        {

            if (string.IsNullOrEmpty(Type)) throw new RequiredInputException("Tipo de objeto");
            if (string.IsNullOrEmpty(Subject)) throw new RequiredInputException("Nombre o tema");
            if (string.IsNullOrEmpty(RawMaterial)) throw new RequiredInputException("Material constitutivo");

            if (!string.IsNullOrEmpty(Valuation.ToString()) && !Valuation.ToString().All(char.IsDigit)) throw new NotNumberInputException("Avalúo");
            if (!CatalogNumber.All(char.IsDigit)) throw new NotNumberInputException("Número de catálogo");
            if (!RegistryNumber.All(char.IsDigit)) throw new NotNumberInputException("Número de registro");
            if (!OtherNumber.All(char.IsDigit)) throw new NotNumberInputException("Otros números");
            if (!CoveredPieces.ToString().All(char.IsDigit)) throw new NotNumberInputException("Piezas que ampara este registro");
            if (!Height.ToString(CultureInfo.CurrentCulture).All(char.IsDigit)) throw new NotNumberInputException("Alto");
            if (!Width.ToString(CultureInfo.CurrentCulture).All(char.IsDigit)) throw new NotNumberInputException("Largo");
            if (!Length.ToString(CultureInfo.CurrentCulture).All(char.IsDigit)) throw new NotNumberInputException("Espesor");
            if (!Diameter.ToString(CultureInfo.CurrentCulture).All(char.IsDigit)) throw new NotNumberInputException("Diámetro");
            if (!Weight.ToString(CultureInfo.CurrentCulture).All(char.IsDigit)) throw new NotNumberInputException("Peso");

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

            if (ImageSource != null && ImageSource!= "/Resources/Images/notFound.png")
            {
                var directoryTo = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Images");
                Directory.CreateDirectory(directoryTo);
                var pathTo = Path.Combine(directoryTo, StockNumber + Path.GetExtension(ImageSource));
                var files = Directory.GetFiles(
                        Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Images"),
                        StockNumber + "*")
                    .Where(file =>
                        StockNumber.ToString().Equals(Path.GetFileNameWithoutExtension(file)) || Path.GetFileNameWithoutExtension(file).Contains("_")).ToArray(); ;
                foreach (var file in files)
                {
                    File.Delete(file);
                }
                File.Copy(ImageSource, pathTo);
            }

            ImageSource = "/Resources/Images/notFound.png";
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
