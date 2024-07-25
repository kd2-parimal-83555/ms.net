using System.CodeDom.Compiler;
using Ques7;

namespace Ques8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee();
            employee.acceptData();
            Console.WriteLine(employee);
        }
    }

    public class Employee : Person
    {
        private static int count = 0;
        private int _Id;
        private string _designation;
        private int _salary;
        private string _dept;

        public Employee() : base() { 
            this.Id = ++count;
        }


        public Employee( string designation, int salary, string dept , string name, bool gender, Date date, string address) : base(name , gender , date , address)
        {
            
            Id = ++count;
            Designation = designation;
            Salary = salary;
            Dept = dept;
        }

        public string Dept
        {
            get { return _dept; }
            set { _dept = value; }
        }


        public int Salary
        {
            get { return _salary; }
            set { _salary = value; }
        }


        public string Designation
        {
            get { return _designation; }
            set { _designation = value; }
        }


        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public override void acceptData()
        {
            base.acceptData();

            Console.Write("enter Designation: ");
            Designation = Console.ReadLine();

            Console.Write("enter salary: ");
            Salary = int.Parse(Console.ReadLine());

            Console.Write("enter Dept: ");
            Dept = Console.ReadLine();


        }

        public override void printData()
        {
            base.printData();
            Console.WriteLine($"Id : {Id} , Designation : {Designation} , Department : {Dept} , Salary : {Salary}  ");
        }

        public override string ToString()
        {
            return base.ToString() + $" Id : {Id} , Designation : {Designation} , Department : {Dept} , Salary : {Salary}  ";
        }
    }
}
