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
        private string imageSource;
        private string stockNumber;
        private string catalogNumber;
        private string registryNumber;
        private string otherNumber;
        private int coveredPieces;
        private string type;
        private string subject;
        private string author;
        private string period;
        private string culture;
        private string origin;
        private string shape;
        private string inscriptions;
        private string description;
        private string remarks;
        private string collection;
        private int conservationType;
        private double valuation;
        private string rawMaterial;
        private string manufacturingTechnique;
        private string decorativeTechnique;
        private string provenance;
        private string acquisitionMethod;
        private string location;
        private float height;
        private float width;
        private float length;
        private float diameter;
        private float weight;

        public string ImageSource
        {
            get => imageSource;
            set { imageSource = value; NotifyPropertyChanged(); }
        } //imagen

        //numeros from table pieza
        public string StockNumber
        {
            get => stockNumber;
            set { stockNumber = value; NotifyPropertyChanged(); }
        } //Numero_de_inventario (generado)

        public string CatalogNumber
        {
            get => catalogNumber;
            set { catalogNumber = value; NotifyPropertyChanged(); }
        } //Numero_de_catalogo

        public string RegistryNumber
        {
            get => registryNumber;
            set { registryNumber = value; NotifyPropertyChanged(); }
        } //Numero_de_registro

        public string OtherNumber
        {
            get => otherNumber;
            set { otherNumber = value; NotifyPropertyChanged(); }
        } //Otro_numero

        //verificacion from table pieza
        public int CoveredPieces
        {
            get => coveredPieces;
            set { coveredPieces = value; NotifyPropertyChanged(); }
        } //Cantidad_ampara

        //descripcion basica from table descripcion
        public string Type
        {
            get => type;
            set { type = value; NotifyPropertyChanged(); }
        } //Tipo_de_objeto

        public string Subject
        {
            get => subject;
            set { subject = value; NotifyPropertyChanged(); }
        } //Nombre_o_tema

        public string Author
        {
            get => author;
            set { author = value; NotifyPropertyChanged(); }
        } //Autor

        public string Period
        {
            get => period;
            set { period = value; NotifyPropertyChanged(); }
        } //Epoca

        public string Culture
        {
            get => culture;
            set { culture = value; NotifyPropertyChanged(); }
        } //Cultura

        public string Origin
        {
            get => origin;
            set { origin = value; NotifyPropertyChanged(); }
        } //Origen

        //descripcion_visual from table descripcion
        public string Shape
        {
            get => shape;
            set { shape = value; NotifyPropertyChanged(); }
        } //Forma

        public string Inscriptions
        {
            get => inscriptions;
            set { inscriptions = value; NotifyPropertyChanged(); }
        } //Inscripciones

        public string Description
        {
            get => description;
            set { description = value; NotifyPropertyChanged(); }
        } //Descripcion

        public string Remarks
        {
            get => remarks;
            set { remarks = value; NotifyPropertyChanged(); }
        } //Observaciones

        //acervo from table descripcion
        public string Collection
        {
            get => collection;
            set { collection = value; NotifyPropertyChanged(); }
        } //Acervo

        //conservacion from table description
        public int ConservationType
        {
            get => conservationType;
            set { conservationType = value; NotifyPropertyChanged(); }
        } //Conservacion

        //avaluo from table description
        public double Valuation
        {
            get => valuation;
            set { valuation = value; NotifyPropertyChanged(); }
        } //Avaluo

        //composicion from table composicion
        public string RawMaterial
        {
            get => rawMaterial;
            set { rawMaterial = value; NotifyPropertyChanged(); }
        } //Materia_prima

        public string ManufacturingTechnique
        {
            get => manufacturingTechnique;
            set { manufacturingTechnique = value; NotifyPropertyChanged(); }
        } //Tecnica_de_manufactura

        public string DecorativeTechnique
        {
            get => decorativeTechnique;
            set { decorativeTechnique = value; NotifyPropertyChanged(); }
        } //Tecnica_decorativa

        //adquisicion from table adquisicion
        public string Provenance
        {
            get => provenance;
            set { provenance = value; NotifyPropertyChanged(); }
        } //Procedencia

        public string AcquisitionMethod
        {
            get => acquisitionMethod;
            set { acquisitionMethod = value; NotifyPropertyChanged(); }
        } //Metodo_de_adquisicion

        //ubicacion from table ubicacion
        public string Location
        {
            get => location;
            set { location = value; NotifyPropertyChanged(); }
        } //Ubicacion_Actual

        //medidas from table medidas
        public float Height
        {
            get => height;
            set { height = value; NotifyPropertyChanged(); }
        } //Alto

        public float Width
        {
            get => width;
            set { width = value; NotifyPropertyChanged(); }
        } //Ancho

        public float Length
        {
            get => length;
            set { length = value; NotifyPropertyChanged(); }
        } //Largo

        public float Diameter
        {
            get => diameter;
            set { diameter = value; NotifyPropertyChanged(); }
        } //Diametro

        public float Weight
        {
            get => weight;
            set { weight = value; NotifyPropertyChanged(); }
        } //Peso

        public RelayCommand ReturnToCollections { get; private set; }
        public RelayCommand BackToCollections { get; private set; }

        public BaseItemOpWindowViewModel()
        {
            ReturnToCollections = new RelayCommand(ReturnToCollectionsExec);
            BackToCollections = new RelayCommand(BackToCollectionsExec);
        }

        public void ReturnToCollectionsExec(object args)
        {
            navigatorService.NativigateToCollections(ViewId, CollectionsViewModel.user, NavigatorService.NavigationMode.MODAL);
        }

        public void BackToCollectionsExec(object args)
        {
            navigatorService.Close(ViewId);
        }
    }
}
