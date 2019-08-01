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
    /// Lógica de interacción para ItemDetailMeasure.xaml
    /// </summary>
    public partial class ItemDetailMeasure : UserControl
    {


        public float MeasureValue
        {
            get { return (float)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("MeasureValue", typeof(float), typeof(ItemDetailMeasure), new PropertyMetadata(0.0f));

        public string MeasureName
        {
            get { return (string)GetValue(MeasureNameProperty); }
            set { SetValue(MeasureNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MeasureName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MeasureNameProperty =
            DependencyProperty.Register("MeasureName", typeof(string), typeof(ItemDetailMeasure), new PropertyMetadata(null));



        public ItemDetailMeasure()
        {
            InitializeComponent();
        }
    }
}
