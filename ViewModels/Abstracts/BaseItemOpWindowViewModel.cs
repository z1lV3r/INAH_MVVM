using INAH.Commands;
using INAH.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INAH.Models;
using INAH.Services.DataServices;

namespace INAH.ViewModels.Abstracts
{
    public abstract class BaseItemOpWindowViewModel : BaseWindowViewModel
    {
        private string imageSource; //imagen

        //numeros from table pieza
        private int stockNumber; //Numero_de_inventario (generado)
        private string catalogNumber; //Numero_de_catalogo
        private string registryNumber; //Numero_de_registro
        private string otherNumber; //Otro_numero

        //verificacion from table pieza
        private int? coveredPieces; //Cantidad_ampara

        //descripcion basica from table descripcion
        private string type; //Tipo_de_objeto
        private string subject; //Nombre_o_tema
        private string author; //Autor
        private string period; //Epoca
        private string culture; //Cultura
        private string origin; //Origen

        //descripcion_visual from table descripcion
        private string shape; //Forma
        private string inscriptions; //Inscripciones
        private string description; //Descripcion
        private string remarks; //Observaciones

        //acervo from table descripcion
        private string collection; //Acervo

        //conservacion from table description
        private int? conservationType; //Conservacion

        //avaluo from table description
        private float? valuation; //Avaluo

        //composicion from table composicion
        private string rawMaterial; //Materia_prima
        private string manufacturingTechnique; //Tecnica_de_manufactura
        private string decorativeTechnique; //Tecnica_decorativa

        //adquisicion from table adquisicion
        private string provenance; //Procedencia
        private string acquisitionMethod; //Metodo_de_adquisicion

        //ubicacion from table ubicacion
        private string location; //Ubicacion_Actual

        //medidas from table medidas
        private float height; //Alto
        private float width; //Ancho
        private float length; //Largo
        private float diameter; //Diametro
        private float weight; //Peso

        protected int userId;

        protected PieceDetailsDataService pieceDetailsDataService;
        protected PiecesDataService piecesDataService;
        protected IdentifiersDataService identifiersService;
        protected MeasuresDataService measuresDataService;

        public string ImageSource
        {
            get => imageSource;
            set { imageSource = value; NotifyPropertyChanged(); }
        } 

        public int StockNumber
        {
            get => stockNumber;
            set { stockNumber = value; NotifyPropertyChanged(); }
        }

        public string CatalogNumber
        {
            get => catalogNumber;
            set { catalogNumber = value; NotifyPropertyChanged(); }
        }

        public string RegistryNumber
        {
            get => registryNumber;
            set { registryNumber = value; NotifyPropertyChanged(); }
        }

        public string OtherNumber
        {
            get => otherNumber;
            set { otherNumber = value; NotifyPropertyChanged(); }
        }

        public int? CoveredPieces
        {
            get => coveredPieces;
            set { coveredPieces = value; NotifyPropertyChanged(); }
        }

        public string Type
        {
            get => type;
            set { type = value; NotifyPropertyChanged(); }
        }

        public string Subject
        {
            get => subject;
            set { subject = value; NotifyPropertyChanged(); }
        }

        public string Author
        {
            get => author;
            set { author = value; NotifyPropertyChanged(); }
        }

        public string Period
        {
            get => period;
            set { period = value; NotifyPropertyChanged(); }
        }

        public string Culture
        {
            get => culture;
            set { culture = value; NotifyPropertyChanged(); }
        }

        public string Origin
        {
            get => origin;
            set { origin = value; NotifyPropertyChanged(); }
        }

        public string Shape
        {
            get => shape;
            set { shape = value; NotifyPropertyChanged(); }
        }

        public string Inscriptions
        {
            get => inscriptions;
            set { inscriptions = value; NotifyPropertyChanged(); }
        }

        public string Description
        {
            get => description;
            set { description = value; NotifyPropertyChanged(); }
        }

        public string Remarks
        {
            get => remarks;
            set { remarks = value; NotifyPropertyChanged(); }
        }

        public string Collection
        {
            get => collection;
            set { collection = value; NotifyPropertyChanged(); }
        }


        public int? ConservationType
        {
            get => conservationType;
            set { conservationType = value; NotifyPropertyChanged(); }
        }

        public float? Valuation
        {
            get => valuation;
            set { valuation = value; NotifyPropertyChanged(); }
        }

        public string RawMaterial
        {
            get => rawMaterial;
            set { rawMaterial = value; NotifyPropertyChanged(); }
        }

        public string ManufacturingTechnique
        {
            get => manufacturingTechnique;
            set { manufacturingTechnique = value; NotifyPropertyChanged(); }
        }

        public string DecorativeTechnique
        {
            get => decorativeTechnique;
            set { decorativeTechnique = value; NotifyPropertyChanged(); }
        }

        public string Provenance
        {
            get => provenance;
            set { provenance = value; NotifyPropertyChanged(); }
        }

        public string AcquisitionMethod
        {
            get => acquisitionMethod;
            set { acquisitionMethod = value; NotifyPropertyChanged(); }
        }

        public string Location
        {
            get => location;
            set { location = value; NotifyPropertyChanged(); }
        }

        public float Height
        {
            get => height;
            set { height = value; NotifyPropertyChanged(); }
        }

        public float Width
        {
            get => width;
            set { width = value; NotifyPropertyChanged(); }
        }

        public float Length
        {
            get => length;
            set { length = value; NotifyPropertyChanged(); }
        }

        public float Diameter
        {
            get => diameter;
            set { diameter = value; NotifyPropertyChanged(); }
        }

        public float Weight
        {
            get => weight;
            set { weight = value; NotifyPropertyChanged(); }
        }

        public RelayCommand ReturnToCollections { get; private set; }
        public RelayCommand BackToCollections { get; private set; }

        protected BaseItemOpWindowViewModel() { }
        protected BaseItemOpWindowViewModel(int id, int userId)
        {
            pieceDetailsDataService = new PieceDetailsDataService();
            piecesDataService = new PiecesDataService();
            identifiersService = new IdentifiersDataService();
            measuresDataService = new MeasuresDataService();
            ReturnToCollections = new RelayCommand(ReturnToCollectionsExec);
            BackToCollections = new RelayCommand(BackToCollectionsExec);

            var piece = piecesDataService.Find(id);
            var details = pieceDetailsDataService.Find(id) ?? new Piece_Details();

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

            ImageSource = Utils.GetImageSource(StockNumber);
        }

        public void ReturnToCollectionsExec(object args)
        {
            ImageSource = "/Resources/Images/notFound.png";
            navigatorService.NavigateToCollections(ViewId, CollectionsViewModel.userId, NavigatorService.NavigationMode.MODAL);
        }

        public void BackToCollectionsExec(object args)
        {
            ImageSource = "/Resources/Images/notFound.png";
            navigatorService.Close(ViewId);
        }
    }
}
