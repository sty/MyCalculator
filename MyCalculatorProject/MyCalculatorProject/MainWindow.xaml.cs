using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyCalculatorProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            History.ItemsSource = Operation;
        }
        
        BinaryOperation _Op = new BinaryOperation();
        ObservableCollection<BinaryOperation> Operation = new ObservableCollection<BinaryOperation>();
        
        private void Number_Clicked(object sender, RoutedEventArgs e)
        {
            _Op.StrOperand += ((Button)sender).Content.ToString();
            Results.Text = _Op.StrOperand;
        }
        private void Operator_Clicked(object sender, RoutedEventArgs e)
        {
            Operation.Add(_Op);
            _Op = new BinaryOperation
            {
                PreviousTotal = _Op.GetResults(),
                Operator = ((Button)sender).Content.ToString()
            };
            Results.Text = _Op.GetResults().ToString();
        }
    }
}
