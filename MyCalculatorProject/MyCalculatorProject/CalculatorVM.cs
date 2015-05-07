using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MyCalculatorProject
{
    class CalculatorVM:BaseVM
    {
        BinaryOperation _Op = new BinaryOperation();
        public BinaryOperation Op
        {
            get { return _Op; }
            set { _Op = value; OnPropertyChanged();  }
        }
        ObservableCollection<Operation> _Operations = new ObservableCollection<Operation>();
        public ObservableCollection<Operation> Operations
        {
            get { return _Operations; }
            set { _Operations = value; OnPropertyChanged(); }
        }
    }
}
