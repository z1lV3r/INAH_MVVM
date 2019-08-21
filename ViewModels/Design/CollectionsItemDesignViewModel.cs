using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INAH.Commands;
using INAH.Services;
using INAH.Services.DataServices;

namespace INAH.ViewModels.Design
{
    public class CollectionsItemDesignViewModel : CollectionsItemViewModel
    {
        public CollectionsItemDesignViewModel()
        {
        }

        public CollectionsItemDesignViewModel(int id)
        {
            piecesDataService = new PiecesDataService();
            fileService = new FileService();

            Id = id;
            Image = GetImagePath(id);
            Name = GetName(id);
            ShowDetailCommand = new RelayCommand(ShowDetailCommandExec);
            EditCommand = new RelayCommand(EditCommandExec);
            DeleteCommand = new RelayCommand(DeleteCommandExec);
        }

        private string GetImagePath(int id)
        {
            var files = Directory.GetFiles(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Images"), id.ToString() + "*");
            return files.Length > 0 ? files.First() : "/Resources/Images/notFound.png";
        }

        public string GetName(int id)
        {
            var list = new[] { "Caja", "JARRON", "PLATO", "JARRON", "JABONERA", "TETERA", "CAFETERA", "TINTERO", "CASCO DE GRANADERO", "Tintero", "Arcon metalico", "CUERO", "URNA CEREMONIAL SACERDOTE GUERRERO", "JARRON" };
            return list[id - 1];
        }
    }
}
