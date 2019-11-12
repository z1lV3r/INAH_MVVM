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
using INAH.Views.Validations;
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

            Validations.NotNullValidation(ViewId, "Tipo de objeto", Type);
            Validations.NotNullValidation(ViewId, "Nombre o tema", Subject);
            Validations.NotNullValidation(ViewId, "Material constitutivo", RawMaterial);

            Validations.IntegerValidation(ViewId, "Avalúo", Valuation.ToString());
            Validations.IntegerValidation(ViewId, "Número de catálogo", CatalogNumber);
            Validations.IntegerValidation(ViewId, "Número de registro", RegistryNumber);
            Validations.IntegerValidation(ViewId, "Otros números", OtherNumber);
            Validations.IntegerValidation(ViewId, "Piezas que ampara este registro", CoveredPieces.ToString());

            Validations.FloatValidation(ViewId, "Alto", Height);
            Validations.FloatValidation(ViewId, "Largo", Width);
            Validations.FloatValidation(ViewId, "Espesor", Length);
            Validations.FloatValidation(ViewId, "Diámetro", Diameter);
            Validations.FloatValidation(ViewId, "Peso", Weight);

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
            else identifiersService.Delete(StockNumber, "Catalog");

            if (RegistryNumber != default) identifiersService.Upsert(StockNumber, "Registry", RegistryNumber);
            else identifiersService.Delete(StockNumber, "Registry");

            if (OtherNumber != default) identifiersService.Upsert(StockNumber, "Other", OtherNumber);
            else identifiersService.Delete(StockNumber, "Other");

            if (!string.IsNullOrEmpty(Height))
            {
                var floatHeight = float.Parse(Height);
                if (floatHeight > default(float)) measuresDataService.Upsert(StockNumber, "Height", floatHeight);
            }
            else
            {
                measuresDataService.Delete(StockNumber, "Height");
            }

            if (!string.IsNullOrEmpty(Width))
            {
                var floatWidth = float.Parse(Width);
                if (floatWidth > default(float)) measuresDataService.Upsert(StockNumber, "Width", floatWidth);
            }
            else
            {
                measuresDataService.Delete(StockNumber, "Width");
            }

            if (!string.IsNullOrEmpty(Length))
            {
                var floatLength = float.Parse(Length);
                if (floatLength > default(float)) measuresDataService.Upsert(StockNumber, "Length", floatLength);
            }
            else
            {
                measuresDataService.Delete(StockNumber, "Length");
            }

            if (!string.IsNullOrEmpty(Diameter))
            {
                var floatDiameter = float.Parse(Diameter);
                if (floatDiameter > default(float)) measuresDataService.Upsert(StockNumber, "Diameter", floatDiameter);
            }
            else
            {
                measuresDataService.Delete(StockNumber, "Diameter");
            }

            if (!string.IsNullOrEmpty(Weight))
            {
                var floatWeight = float.Parse(Weight);
                if (floatWeight > default(float)) measuresDataService.Upsert(StockNumber, "Weight", floatWeight);
            }
            else
            {
                measuresDataService.Delete(StockNumber, "Weight");
            }

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
