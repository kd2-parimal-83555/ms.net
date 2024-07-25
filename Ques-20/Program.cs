/*Create event “EmpListChanged” in Company class. Event must be fired when
employee is added or removed from the company. Event handler in client project
should take care of updating salary expense of the company.*/

namespace Assignment_20
{
    public delegate void EmployeeChange();
    internal class Program
    {
        static int Menu()
        {
            int choice;
            Console.WriteLine("-----Company Menu-----");
            Console.WriteLine("0. Press to Exit");
            Console.WriteLine("1. Press to Add Employee");
            Console.WriteLine("2. Press to Remove Employee");
            Console.WriteLine("3. Press to Find Employee by id");
            Console.WriteLine("4. Press to Display Company Info");
            Console.WriteLine("5. Press to Display all Employeees");
            Console.WriteLine("Enter Choice:");
            choice = Convert.ToInt32(Console.ReadLine());
            return choice; ;
        }
        static void Main(string[] args)
        {
            Company company = new Company();
            EmployeeChange dele = new EmployeeChange(company.CalculateSalaryExpense);
            company.FinaceReCheck += dele;
            company.Accept();
            int ch;
            while ((ch = Menu()) != 0)
            {
                switch (ch)
                {
                    case 1:
                        company.AddEmployee(new Employee());
                        break;
                    case 2:
                        Console.WriteLine("Enter id of Employee to Fire:");
                        company.RemoveEmployee(Convert.ToInt32(Console.ReadLine()));
                        break;
                    case 3:
                        Console.WriteLine("Enter id of Employee to Find:");
                        LinkedListNode<Employee> emp = company.FindEmployee(Convert.ToInt32(Console.ReadLine()));
                        if (emp != null)
                        {
                            Console.WriteLine(emp.Value);
                        }
                        else
                        {
                            Console.WriteLine("No Such Employee Found");
                        }
                        break;
                    case 4:
                        company.Print();
                        break;
                    case 5:
                        company.PrintEmployees();
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            }
            Console.WriteLine("Thanks for Using");
        }
    }
}
