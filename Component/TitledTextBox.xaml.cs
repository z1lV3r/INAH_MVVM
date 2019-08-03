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
        public static readonly DependencyProperty TextBoxHeightProperty = DependencyProperty.Register("TextBoxHeight", typeof(int), typeof(TitledTextBox), new PropertyMetadata(25));
        public static readonly DependencyProperty TextBoxMaxWidthProperty = DependencyProperty.Register("TextBoxMaxWidth", typeof(int), typeof(TitledTextBox), new PropertyMetadata(287));
        public static readonly DependencyProperty TextBoxTextWrappingProperty = DependencyProperty.Register("TextBoxTextWrapping", typeof(TextWrapping), typeof(TitledTextBox), new PropertyMetadata(TextWrapping.NoWrap));
        public static readonly DependencyProperty TextBoxAcceptsReturnProperty = DependencyProperty.Register("TextBoxAcceptsReturn", typeof(bool), typeof(TitledTextBox), new PropertyMetadata(false));
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(TitledTextBox), new PropertyMetadata(default(string)));
        public static readonly DependencyProperty HasHelpProperty = DependencyProperty.Register("HasHelp", typeof(bool), typeof(TitledTextBox), new PropertyMetadata(true));
        public static readonly DependencyProperty HasToLowerCaseProperty = DependencyProperty.Register("HasToLowerCase", typeof(bool), typeof(TitledTextBox), new PropertyMetadata(true));
        public static readonly DependencyProperty TextBoxMarginProperty = DependencyProperty.Register("TextBoxMargin", typeof(Thickness), typeof(TitledTextBox), new PropertyMetadata(new Thickness(0,0,20,0)));

        public TitledTextBox()
        {
            InitializeComponent();
        }

        public string Title
        {
            get => (string) GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public int TextBoxHeight
        {
            get => (int) GetValue(TextBoxHeightProperty);
            set => SetValue(TextBoxHeightProperty, value);
        }

        public int TextBoxMaxWidth
        {
            get => (int) GetValue(TextBoxMaxWidthProperty);
            set => SetValue(TextBoxMaxWidthProperty, value);
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

        public bool HasHelp
        {
            get => (bool) GetValue(HasHelpProperty);
            set => SetValue(HasHelpProperty, value);
        }

        public bool HasToLowerCase
        {
            get => (bool) GetValue(HasToLowerCaseProperty);
            set => SetValue(HasToLowerCaseProperty, value);
        }

        public Thickness TextBoxMargin
        {
            get => (Thickness) GetValue(TextBoxMarginProperty);
            set => SetValue(TextBoxMarginProperty, value);
        }
    }
}
