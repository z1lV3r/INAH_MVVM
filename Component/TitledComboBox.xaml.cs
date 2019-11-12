using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace INAH.Component
{
    /// <summary>
    /// Lógica de interacción para TitledComboBox.xaml
    /// </summary>
    public partial class TitledComboBox : UserControl
    {
        public static readonly DependencyProperty ComboBoxItemsSourceProperty;
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(TitledComboBox), new PropertyMetadata(default(string)));
        public static readonly DependencyProperty ComboBoxSelectedItemProperty = DependencyProperty.Register("ComboBoxSelectedItem", typeof(string), typeof(TitledComboBox), new PropertyMetadata(default(string)));

        static TitledComboBox()
        {
            TitledComboBox.ComboBoxItemsSourceProperty =
                DependencyProperty.Register("ComboBoxItemsSource",
                    typeof(IEnumerable), typeof(TitledComboBox));
        }

        public IEnumerable ComboBoxItemsSource
        {
            get => (IEnumerable)GetValue(TitledComboBox.ComboBoxItemsSourceProperty);
            set => SetValue(TitledComboBox.ComboBoxItemsSourceProperty, value);
        }

        public string Title
        {
            get => (string) GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public string ComboBoxSelectedItem
        {
            get => (string) GetValue(ComboBoxSelectedItemProperty);
            set => SetValue(ComboBoxSelectedItemProperty, value);
        }

        public TitledComboBox()
        {
            InitializeComponent();
        }
    }
}
