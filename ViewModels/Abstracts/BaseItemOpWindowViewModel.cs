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
        public string ImageSource { get; set; }     //imagen

        //numeros from table pieza
        public string StockNumber { get; set; }     //Numero_de_inventario (generado)
        public string CatalogNumber { get; set; }   //Numero_de_catalogo
        public string RegistryNumber { get; set; }  //Numero_de_registro
        public string OtherNumber { get; set; }     //Otro_numero

        //verificacion from table pieza
        public int CoveredPieces { get; set; }      //Cantidad_ampara

        //descripcion basica from table descripcion
        public string Type { get; set; }            //Tipo_de_objeto
        public string Subject { get; set; }         //Nombre_o_tema
        public string Author { get; set; }          //Autor
        public string Period { get; set; }          //Epoca
        public string Culture { get; set; }         //Cultura
        public string Origin { get; set; }          //Origen

        //descripcion_visual from table descripcion
        public string Shape { get; set; }           //Forma
        public string Inscriptions { get; set; }    //Inscripciones
        public string Description { get; set; }     //Descripcion
        public string Remarks { get; set; }         //Observaciones

        //acervo from table descripcion
        public string Collection { get; set; }      //Acervo

        //conservacion from table description
        public int ConservationType { get; set; }   //Conservacion

        //avaluo from table description
        public double Valuation { get; set; }          //Avaluo

        //composicion from table composicion
        public string RawMaterial { get; set; }             //Materia_prima
        public string ManufacturingTechnique { get; set; }  //Tecnica_de_manufactura
        public string DecorativeTechnique { get; set; }     //Tecnica_decorativa

        //adquisicion from table adquisicion
        public string Provenance { get; set; }          //Procedencia
        public string AcquisitionMethod { get; set; }   //Metodo_de_adquisicion

        //ubicacion from table ubicacion
        public string Location { get; set; }    //Ubicacion_Actual

        //medidas from table medidas
        public float Height { get; set; }   //Alto
        public float Width { get; set; }    //Ancho
        public float Length { get; set; }   //Largo
        public float Diameter { get; set; } //Diametro
        public float Weight { get; set; }   //Peso
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
