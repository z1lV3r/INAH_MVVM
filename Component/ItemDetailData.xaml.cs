using System;
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
    /// Lógica de interacción para ItemDetailData.xaml
    /// </summary>
    public partial class ItemDetailData : UserControl
    {


        public string DetailTittle
        {
            get => (string)GetValue(DetailTittleProperty);
            set => SetValue(DetailTittleProperty, value);
        }

        // Using a DependencyProperty as the backing store for Tittle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DetailTittleProperty =
            DependencyProperty.Register("DetailTittle", typeof(string), typeof(ItemDetailData),
                new PropertyMetadata(string.Empty));



        public string Value
        {
            get => (string)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(string), typeof(ItemDetailData),
                new PropertyMetadata(string.Empty));

        public ItemDetailData()
        {
            InitializeComponent();
        }
    }
}
