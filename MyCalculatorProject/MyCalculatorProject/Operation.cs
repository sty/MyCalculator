using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCalculatorProject
{
    class BinaryOperation
    {
        private float _PreviousTotal;
        public float PreviousTotal
        {
            get { return _PreviousTotal; }
            set { _PreviousTotal = value; }
        }

        private string _Operator = "+";

        public string Operator
        {
            get { return _Operator; }
            set { _Operator = value; }

        }

        private float _Operand;


        public float Operand
        {
            get
            {
                if (! float.TryParse(StrOperand, out _Operand))
                {
                    return PreviousTotal;
                }
                return _Operand;
            }
            set { Operand = value; }
        }


        public string StrOperand { get; set; }


        public float GetResults()
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
        public override string ToString()
        {
            return Operator.ToString() + " " + Operand.ToString();
        }
    }

    public class Operation
    {

    }
}
