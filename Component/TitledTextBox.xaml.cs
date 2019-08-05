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
    /// Lógica de interacción para TitledTextBox.xaml
    /// </summary>
    public partial class TitledTextBox : UserControl
    {
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(TitledTextBox), new PropertyMetadata(default(string)));
        public static readonly DependencyProperty TextBoxHeightProperty = DependencyProperty.Register("TextBoxHeight", typeof(double), typeof(TitledTextBox), new PropertyMetadata(Double.NaN));
        public static readonly DependencyProperty TextBoxTextWrappingProperty = DependencyProperty.Register("TextBoxTextWrapping", typeof(TextWrapping), typeof(TitledTextBox), new PropertyMetadata(TextWrapping.NoWrap));
        public static readonly DependencyProperty TextBoxAcceptsReturnProperty = DependencyProperty.Register("TextBoxAcceptsReturn", typeof(bool), typeof(TitledTextBox), new PropertyMetadata(false));
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(TitledTextBox), new PropertyMetadata(default(string)));
        public static readonly DependencyProperty HasToLowerCaseProperty = DependencyProperty.Register("HasToLowerCase", typeof(bool), typeof(TitledTextBox), new PropertyMetadata(true));
        public static readonly DependencyProperty TitledTextBoxMarginProperty = DependencyProperty.Register("TitledTextBoxMargin", typeof(Thickness), typeof(TitledTextBox), new PropertyMetadata(new Thickness(0,0,20,0)));
        public static readonly DependencyProperty TextBoxHorizontalContentAlignmentProperty = DependencyProperty.Register("TextBoxHorizontalContentAlignment", typeof(HorizontalAlignment), typeof(TitledTextBox), new PropertyMetadata(HorizontalAlignment.Left));
        public static readonly DependencyProperty PostfixTextProperty = DependencyProperty.Register("PostfixText", typeof(string), typeof(TitledTextBox), new PropertyMetadata(string.Empty));
        public static readonly DependencyProperty PrefixTextProperty = DependencyProperty.Register("PrefixText", typeof(string), typeof(TitledTextBox), new PropertyMetadata(string.Empty));
        public static readonly DependencyProperty TextBoxMaxHeightProperty = DependencyProperty.Register("TextBoxMaxHeight", typeof(double), typeof(TitledTextBox), new PropertyMetadata(double.PositiveInfinity));
        public static readonly DependencyProperty HelpTextProperty = DependencyProperty.Register("HelpText", typeof(string), typeof(TitledTextBox), new PropertyMetadata(default(string)));

        public TitledTextBox()
        {
            InitializeComponent();
        }

        public string Title
        {
            get => (string) GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public double TextBoxHeight
        {
            get => (double) GetValue(TextBoxHeightProperty);
            set => SetValue(TextBoxHeightProperty, value);
        }

        public TextWrapping TextBoxTextWrapping
        {
            get => (TextWrapping) GetValue(TextBoxTextWrappingProperty);
            set => SetValue(TextBoxTextWrappingProperty, value);
        }

        public bool TextBoxAcceptsReturn
        {
            get => (bool) GetValue(TextBoxAcceptsReturnProperty);
            set => SetValue(TextBoxAcceptsReturnProperty, value);
        }

        public string Text
        {
            get => (string) GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public bool HasToLowerCase
        {
            get => (bool) GetValue(HasToLowerCaseProperty);
            set => SetValue(HasToLowerCaseProperty, value);
        }

        public Thickness TitledTextBoxMargin
        {
            get => (Thickness) GetValue(TitledTextBoxMarginProperty);
            set => SetValue(TitledTextBoxMarginProperty, value);
        }

        public HorizontalAlignment TextBoxHorizontalContentAlignment
        {
            get => (HorizontalAlignment) GetValue(TextBoxHorizontalContentAlignmentProperty);
            set => SetValue(TextBoxHorizontalContentAlignmentProperty, value);
        }

        public string PostfixText
        {
            get => (string) GetValue(PostfixTextProperty);
            set => SetValue(PostfixTextProperty, value);
        }

        public string PrefixText
        {
            get => (string) GetValue(PrefixTextProperty);
            set => SetValue(PrefixTextProperty, value);
        }

        public double TextBoxMaxHeight
        {
            get => (double) GetValue(TextBoxMaxHeightProperty);
            set => SetValue(TextBoxMaxHeightProperty, value);
        }

        public string HelpText
        {
            get => (string) GetValue(HelpTextProperty);
            set => SetValue(HelpTextProperty, value);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Text = Text.ToLower();
        }
    }
}
