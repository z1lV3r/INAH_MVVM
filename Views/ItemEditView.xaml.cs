using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using INAH.Component;

namespace INAH.Views
{
    /// <summary>
    /// Lógica de interacción para ItemEditView.xaml
    /// </summary>
    public partial class ItemEditView : Window
    {
        public ItemEditView()
        {
            InitializeComponent();
        }

        private void ValidateOnlyNumbers(object sender, RoutedEventArgs e)
        {
            var titledTextBox = (TitledTextBox) sender;
            titledTextBox.ErrorText = string.Empty;
            if (!string.IsNullOrEmpty(titledTextBox.Text) && !titledTextBox.Text.All(char.IsDigit))
            {
                titledTextBox.ErrorText = "Este campo solo permite datos numericos";
            }

        }

        private void RequiredField(object sender, RoutedEventArgs e)
        {
            var titledTextBox = (TitledTextBox)sender;
            titledTextBox.ErrorText = string.Empty;
            if (string.IsNullOrEmpty(titledTextBox.Text))
            {
                titledTextBox.ErrorText = "Este campo es obligatorio";
            }
        }

        private void ValidateOnlyFloats(object sender, RoutedEventArgs e)
        {
            var titledTextBox = (TitledTextBox)sender;
            titledTextBox.ErrorText = string.Empty;
            var regex = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");
            if (!string.IsNullOrEmpty(titledTextBox.Text) && (!regex.IsMatch(titledTextBox.Text) || float.Parse(titledTextBox.Text) <= 0f))
            {
                titledTextBox.ErrorText = "Este campo solo permite datos numericos decimales positivos";
            }
        }
    }
}
