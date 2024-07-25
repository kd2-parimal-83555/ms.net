using Ques7;
using Ques8;

namespace Ques10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Supervisor s = new Supervisor();
            s.acceptData();
            s.printData();
            Console.WriteLine(s);

        }
    }

    public class Supervisor : Employee
    {
        private int _subbordinates;

        public int Subord
        {
            get { return _subbordinates; }
            set { _subbordinates = value; }
        }

        public Supervisor() { }

        public Supervisor(int Subord, string designation, int salary, string dept, string name, bool gender, Date date, string address) : base(designation, salary, dept, name, gender, date, address)
        {
            this.Subord = Subord;
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

            Console.Write("Enter Subords: ");
            Subord = Convert.ToInt32(Console.ReadLine());
            this.Designation = "Supervisor";
        }

        public override string ToString()
        {
            return base.ToString() + " Subords : " + Subord;
        }

        public override void printData()
        {
            base.printData();
            Console.WriteLine($" Subords : {Subord}");
        }
    }
}
