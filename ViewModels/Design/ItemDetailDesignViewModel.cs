using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INAH.ViewModels.Design
{
    public class ItemDetailDesignViewModel : ItemDetailViewModel
    {
        public ItemDetailDesignViewModel()
        {
            ImageSource = "/Resources/Images/notFound.png"; //imagen

            //numeros from table pieza
            StockNumber = 1; //Numero_de_inventario (generado)
            CatalogNumber = "catalogNumber dummy"; //Numero_de_catalogo
            RegistryNumber = "registryNumber dummy"; //Numero_de_registro
            OtherNumber = "otherNumber dummy"; //Otro_numero

            //verificacion from table pieza
            CoveredPieces = 1; //Cantidad_ampara

            //descripcion basica from table descripcion
            Type = "type dummy"; //Tipo_de_objeto
            Subject = "subject dummy"; //Nombre_o_tema
            Author = "author dummy"; //Autor
            Period = "period dummy"; //Epoca
            Culture = "culture dummy"; //Cultura
            Origin = "origin dummy"; //Origen

            //descripcion_visual from table descripcion
            Shape = "shape dummy"; //Forma
            Inscriptions = "inscriptions dummy"; //Inscripciones
            Description = "description dummy"; //Descripcion
            Remarks = "remarks dummy"; //Observaciones

            //acervo from table descripcion
            Collection = "collection dummy"; //Acervo

            //conservacion from table description
            ConservationType = 1; //Conservacion

            //avaluo from table description
            Valuation = 2.2f; //Avaluo

            //composicion from table composicion
            RawMaterial = "rawMaterial dummy"; //Materia_prima
            ManufacturingTechnique = "manufacturingTechnique dummy"; //Tecnica_de_manufactura
            DecorativeTechnique = "decorativeTechnique dummy"; //Tecnica_decorativa

            //adquisicion from table adquisicion
            Provenance = "provenance dummy"; //Procedencia
            AcquisitionMethod = "acquisitionMethod dummy"; //Metodo_de_adquisicion

            //ubicacion from table ubicacion
            Location = "location dummy"; //Ubicacion_Actual

            //medidas from table medidas
            Height = 2.2f; //Alto
            Width = 2.2f; //Ancho
            Length = 2.2f; //Largo
            Diameter = 2.2f; //Diametro
            Weight = 2.2f; //Peso
        }
    }
}
