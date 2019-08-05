using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace INAH.Services.DataServices
{
    class PiecesDataService
    {
        public void Delete(string id)
        {
            MessageBox.Show("Borrado");
        }

        public string GetName(string id)
        {
            var list = new[] { "Caja", "JARRON", "PLATO", "JARRON", "JABONERA", "TETERA", "CAFETERA", "TINTERO", "CASCO DE GRANADERO", "Tintero", "Arcon metalico", "CUERO", "URNA CEREMONIAL SACERDOTE GUERRERO", "JARRON" };
            return list[int.Parse(id)-1];
        }
    }
}
