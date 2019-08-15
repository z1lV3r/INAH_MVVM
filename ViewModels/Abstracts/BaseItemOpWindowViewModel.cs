using INAH.Commands;
using INAH.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INAH.ViewModels.Abstracts
{
    public abstract class BaseItemOpWindowViewModel : BaseWindowViewModel
    {
        private string imageSource; //imagen

        //numeros from table pieza
        private string stockNumber; //Numero_de_inventario (generado)
        private string catalogNumber; //Numero_de_catalogo
        private string registryNumber; //Numero_de_registro
        private string otherNumber; //Otro_numero

        //verificacion from table pieza
        private int coveredPieces; //Cantidad_ampara

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
        private int conservationType; //Conservacion

        //avaluo from table description
        private double valuation; //Avaluo

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

        public string ImageSource
        {
            get => imageSource;
            set { imageSource = value; NotifyPropertyChanged(); }
        } 

        public string StockNumber
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

        public int CoveredPieces
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


        public int ConservationType
        {
            get => conservationType;
            set { conservationType = value; NotifyPropertyChanged(); }
        }

        public double Valuation
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

        public BaseItemOpWindowViewModel()
        {
            ReturnToCollections = new RelayCommand(ReturnToCollectionsExec);
            BackToCollections = new RelayCommand(BackToCollectionsExec);
        }

        public void ReturnToCollectionsExec(object args)
        {
            navigatorService.NativigateToCollections(ViewId, CollectionsViewModel.userId, NavigatorService.NavigationMode.MODAL);
        }

        public void BackToCollectionsExec(object args)
        {
            navigatorService.Close(ViewId);
        }
    }
}
