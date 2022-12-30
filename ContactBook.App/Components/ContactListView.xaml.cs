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

namespace ContactBook.App.Components
{
    /// <summary>
    /// Logika interakcji dla klasy ContactListView.xaml
    /// </summary>
    public partial class ContactListView : UserControl
    {
        public event Action TextChanged;
        public ContactListView()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextChanged.Invoke();
        }
    }
}
