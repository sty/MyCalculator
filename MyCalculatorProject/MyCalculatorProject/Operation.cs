
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyCalculatorProject
{
    public class Operation:BaseVM
    {
        private string _Operator = "+";
        public string Operator
        {
            get { return _Operator; }
            set { _Operator = value; OnPropertyChanged(); OnPropertyChanged("DisplayText"); }
        }
        private float _PreviousTotal;
        public float PreviousTotal
        {
            get { return _PreviousTotal; }
            set { _PreviousTotal = value; OnPropertyChanged(); OnPropertyChanged("DisplayText"); }
        }
        public virtual string DisplayText
        {
            get { return GetResults.ToString(); }

        }
        public virtual float GetResults
        {
            get
            {
                switch (Operator)
                {
                    case "sq":
                        return PreviousTotal * PreviousTotal;
                    case "sqrt":
                        return (float)Math.Sqrt((double)PreviousTotal);
                    case "+/-":
                        return -PreviousTotal;
                    case "=":
                        return PreviousTotal;
                }
                return PreviousTotal;
            }
        }
        public override string ToString()
        {
            return Operator.ToString() + " " + PreviousTotal.ToString();
        }
    }
    public class BinaryOperation : Operation
    {
        public override string DisplayText
        {
           
                 get
                   {
                     if (string.IsNullOrWhiteSpace(StrOperand))
                         return PreviousTotal.ToString();
                     else
                         return StrOperand;
                 }

        }

        private string _StrOperand;

        public string StrOperand
        {
            get { return _StrOperand; }
            set
            {
                _StrOperand = value;
                OnPropertyChanged();
                OnPropertyChanged("DisplayText");
                OnPropertyChanged("Operand");
                OnPropertyChanged("GetResults");
            }
        }


        private float _Operand;
        public float Operand
        {
            get
            {
                if (!float.TryParse(StrOperand, out _Operand))
                {
                    return PreviousTotal;
                }
                return _Operand;
            }
        }
        public override float GetResults
        {
            get
            {
                switch (Operator)
                {
                    case "+":
                        return PreviousTotal + Operand;
                    case "-":
                        return PreviousTotal - Operand;
                    case "x":
                        return PreviousTotal * Operand;
                    case "/":
                        return PreviousTotal / Operand;
                }
                return PreviousTotal;
            }
        }
        public override string ToString()
        {
            return Operator.ToString() + " " + Operand.ToString();
        }
    }
    public class BaseVM:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

            }
        }

        
    }
   
}