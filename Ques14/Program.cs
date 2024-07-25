using EmployeeLib;
using System.Transactions;
namespace Ques14
{
    internal class Program
    {
        public static int menu()
        {
            int choice;
            Console.WriteLine("Add employee to Company:- press 1");
            Console.WriteLine("Removing employee to Company:- press 2");
            Console.WriteLine("find employee by id employee to Company:- press 3");
            Console.WriteLine("Display All Info:- press 4");
            Console.WriteLine("Enter choice..........");
            choice = Convert.ToInt32(Console.ReadLine());
            return choice;
        }

        static void Main(string[] args)
        {
            int choice , choice1;
            Company company = new Company();
            Factory factory = new Factory();
            company.acceptData();
            while((choice = menu()) != 0)
            {
               switch (choice)
                {
                    case 0:
                        Console.WriteLine("Exit...");
                        break;

                    case 1:
                        Console.WriteLine("Adding Employee");
                        Employee emp;
                        Console.WriteLine("1: Wage Employee , 2: Manager , 3: Supervisor  ,4:Employee");
                        choice1 = Convert.ToInt32(Console.ReadLine());
                        emp = factory.getEmployee(choice1);
                        
                        emp.acceptData();
                        company.addEmployee(emp);
                        break;

                    case 2:
                        Console.WriteLine("Removing Employee");
                        Console.Write("Enter the ID:- ");
                        choice1 = Convert.ToInt32(Console.ReadLine());
                        company.removeEmployee(choice1);
                        break;
                    
                    case 3:
                        Console.WriteLine("Finding the Employee");
                        Console.Write("Enter the ID:- ");
                        choice1 = Convert.ToInt32(Console.ReadLine());
                        company.findEmployee(choice1);
                        break;
                    case 4:
                        Console.WriteLine("Details of the Employee");
                        company.printEmployees();
                    break;
                }
            }
        }
    }
    
    public  class Factory
    {
        public Employee getEmployee(int choice)
        {
            if(choice == 1) { 
                return new WageEmp();
            }
            else if(choice == 2)
            {
                return new Manager();
            }
            else if(choice == 4)
            {
                return new Employee();
            }
            else if( choice == 3)
            {
                return new Supervisor();
            }
            return null;
        }
    }
}
