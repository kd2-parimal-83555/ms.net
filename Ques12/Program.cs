using Ques7;
using Ques8;
using Ques9;
using Ques10;
using Ques11;
using System.CodeDom.Compiler;
using System.Net;
using System.Xml.Linq;


namespace Ques12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Company company = new Company();
            company.acceptData();
            Console.WriteLine("Enter the no of Employees");
            int len = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < len; i++)
            {   Employee e = new Employee();
                e.acceptData();
                company.addEmployee(e);
            }
            company.printData();
        }
    }

    public class Company
    {
        private string _name;
        private string _address;
        private LinkedList<Employee> employees;
        private double _salaryExepense;

        public LinkedList<Employee> Employees
        {
            get { return employees; }
            set { employees = value; }
        }

        public double SalaryExpense
        {
            get { return _salaryExepense; }
            set {  _salaryExepense = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Company()
        {
            Employees = new LinkedList<Employee>();
        }

        public void acceptData()
        {
            Console.Write("Enter Company's Name....");
            Name =  Console.ReadLine();
            Console.Write("Enter Company's Address....");
            Address = Console.ReadLine();
            this.SalaryExpense = 0;

        }

        public void printData()
        {
            Console.WriteLine("Company's name : " +  Name + "Company's Address : " + Address + " SalaryExpense : " + calculateSalaryExpense());
            printEmployees();
                   
        }

        public void printEmployees()
        {
            foreach (Employee e in Employees)
            {
                Console.WriteLine(e);
            }
        }

        public double calculateSalaryExpense()
        {   
            double salarytotal = 0 ;
            foreach (Employee e in Employees)
            {
                salarytotal += e.Salary;
            }
            return salarytotal;
        }

        public void addEmployee(Employee e)
        {
            employees.AddLast(e);
        }

        public bool removeEmployee(int id)
        {
            foreach (Employee e in employees)
            {
                if (e.Id == id)
                {
                    employees.Remove(e);
                    break;
                }
            }
            return false ;
        }

        public LinkedListNode<Employee> findEmployee(int id)
        {
            LinkedListNode<Employee> node;

            for(node = employees.First; node!= null;node= node.Next)
            {
                if(node.Value.Id == id)
                {
                    return node;
                }
            }
            return null;
        }

        public override string ToString()
        {
            return $"Company Name: {Name}, Address: {Address}, Total Salary Expense: {SalaryExpense}";
        }

    }
}
