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
        private CbDb _VM = new CbDb();
        public CheckBook()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
         
            System.Windows.Data.CollectionViewSource transactionViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("transactionViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // transactionViewSource.Source = [generic data source]
            _VM.Transactions.ToList();
        }
    }
}
