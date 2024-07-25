using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign7
{
    internal class Manager: Employee
    {
        private double _Bonus;

        public double Bonus {

            get { return _Bonus; } 
            set { _Bonus = value; }
        }

        public Manager()
        {
           
        }

        public Manager(double bonus)
        {
            _Bonus = bonus;

        }

        public void AcceptManager()
        {
            base.AcceptEmployee();
            Console.WriteLine("Enter  Bonus: ");
            Bonus=Convert.ToDouble(Console.ReadLine());
        }

        public void PrintManager()
        {
            base.PrintEmployee();
            Console.WriteLine("Bonus: " + Bonus);
        }

        public override string ToString()
        {
            return $"base.ToString()+Bonus: {Bonus}";
        }

    }
}
