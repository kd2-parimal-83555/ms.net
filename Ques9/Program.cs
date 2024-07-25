using Ques7;
using Ques8;
namespace Ques9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();
            manager.acceptData();
            manager.printData();
            Console.WriteLine(manager);
            Console.ReadLine();
        }
    }

    public class Manager : Employee
    {
        private double  _bonus;

        public double Bonus
        {
            get { return _bonus; }
            set { _bonus = value; }
        }

        public Manager() { }

        public Manager(double bonus , string designation, int salary, string dept, string name, bool gender, Date date, string address) : base(designation, salary,  dept,  name,  gender,  date,  address)
        {
            this.Bonus = bonus;
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

            Console.Write("Enter Bonus: ");
            Bonus = Convert.ToDouble(Console.ReadLine());
            this.Designation = "Manager";
        }

        public override string ToString()
        {
            return base.ToString() + " Bonus : " + Bonus;
        }

        public override void printData()
        {
            base.printData();
            Console.WriteLine($" Bonus : {Bonus}");
        }

    }
}
