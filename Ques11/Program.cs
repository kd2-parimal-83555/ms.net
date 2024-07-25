using Ques7;
using Ques8;

namespace Ques11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WageEmp emp = new WageEmp();
            emp.acceptData();
            emp.printData();
            Console.WriteLine(emp);
        }
    }

    public class WageEmp : Employee
    {
        private int _hours;
        private int _rate;

        public int Rate
        {
            get { return _rate; }
            set { _rate = value; }
        }


        public int Hours
        {
            get { return _hours; }
            set { _hours = value; }
        }


        public WageEmp() { }
        public WageEmp(int hours, int rate, string designation, int salary, string dept, string name, bool gender, Date date, string address) : base(designation, salary, dept, name, gender, date, address)
        {
            this.Hours = hours;
            this.Rate = rate;
        }

        public override void acceptData()
        {

            Console.Write("enter name: ");
            Name = Console.ReadLine();

            Console.Write("enter gender true for Male and False for Female: ");
            Gender = Convert.ToBoolean(Console.ReadLine());

            Console.Write("enter Address: ");
            Address = Console.ReadLine();

            Console.Write("Enter Birth Day: ");
            int day = int.Parse(Console.ReadLine());

            Console.Write("Enter Birth Month: ");
            int month = int.Parse(Console.ReadLine());

            Console.Write("Enter Birth Year: ");
            int year = int.Parse(Console.ReadLine());

            date = new Date(day, month, year);

            Console.Write("enter salary: ");
            Salary = int.Parse(Console.ReadLine());

            Console.Write("enter Dept: ");
            Dept = Console.ReadLine();

            Console.Write("Enter Hours: ");
            Hours = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Rate: ");
            Rate = Convert.ToInt32(Console.ReadLine());

            this.Designation = "Wages";
        }

        public override string ToString()
        {
            return base.ToString() + " Hours : " + Hours + "Rate : " + Rate;
        }

        public override void printData()
        {
            base.printData();
            Console.WriteLine($" Hours : {Hours} Rate : {Rate}");
        }

    }
}
