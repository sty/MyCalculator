using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyCalculatorProject.CheckBook
{
        public class Account:BaseVM
        {
            public int Id { get; set; }
            private string _Name;
            public string Name
            {
                get { return _Name; }
                set { _Name = value; OnPropertyChanged(); }
            }
            private string _Institution;
            public string Institution
            {
                get { return _Institution; }
                set { _Institution = value; OnPropertyChanged(); }
            }
            private double _Total;
            public double Total
            {
                get { return _Total; }
                set { _Total= value; OnPropertyChanged(); }
            }
        }
    
}
