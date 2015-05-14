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
using System.Windows.Shapes;

namespace MyCalculatorProject.CheckBook
{
    /// <summary>
    /// Interaction logic for CheckBook.xaml
    /// </summary>
    public partial class CheckBook : Window
    {
        
        public CheckBook()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var VM = new CheckBookVM();
            DataContext = VM;
            
            VM.Fill();
            
        }
    }
}
