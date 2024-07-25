/*Create a similar console application and use the library “EmployeeLib” as shared assembly*/

using EmployeeLib_Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeLib_Framework;

namespace Assignment_15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Employee Management System");

            Console.WriteLine("\nEnter the Company Details");
            Company company = new Company();
            company.Accept();

            int choice;

            do
            {
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Remove Employee");
                Console.WriteLine("3. Find Employee by Id");
                Console.WriteLine("4. Display Company Info");
                Console.WriteLine("5. Display All Employees");
                Console.WriteLine("Enter your choice");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        {
                            Console.WriteLine("Enter no. of employees to add");
                            int n = Convert.ToInt32(Console.ReadLine());
                            for (int i = 1; i <= n; i++)
                            {
                                if (i > 0)
                                {
                                    Console.WriteLine();
                                }
                                Console.WriteLine("Enter employee details for employee " + i);
                                Employee employee = new Employee();
                                employee.Accept();
                                company.AddEmployee(employee);
                            }
                            Console.WriteLine();
                            break;
                        }

                    case 2:
                        {
                            Console.WriteLine("Enter employee id to remove");
                            int id = Convert.ToInt32(Console.ReadLine());
                            LinkedList<Employee> employees = company.EmpList;
                            bool isEmployeeAvailable = false;

                            //checking if employee is available or not before removing
                            foreach (Employee emp in employees)
                            {
                                if (emp.Id == id)
                                {
                                    isEmployeeAvailable = true;
                                    break;
                                }
                            }

                            //if employee is not available
                            if (!isEmployeeAvailable)
                            {
                                Console.WriteLine("Employee not found");
                                Console.WriteLine();
                                break;
                            }
                            else
                            {
                                //if employee is available
                                company.RemoveEmployee(id);
                            }

                            Console.WriteLine();
                            break;
                        }

                    case 3:
                        {
                            Console.WriteLine("Enter employee id to find");
                            int id = Convert.ToInt32(Console.ReadLine());
                            LinkedListNode<Employee> emp = company.FindEmployee(id);
                            if (emp != null)
                            {
                                Employee empl = emp.Value;
                                Console.WriteLine(empl);
                            }
                            else
                            {
                                Console.WriteLine("Employee not found");
                            }

                            Console.WriteLine();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("\nCompany Name: " + company.Name);
                            Console.WriteLine("Company Address: " + company.Address);
                            Console.WriteLine();
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("All the employees working in " + company.Name + " are:");
                            LinkedList<Employee> employees = company.EmpList;
                            foreach (Employee emp1 in employees)
                            {
                                Console.WriteLine("\nId: " + emp1.Id);
                                Console.WriteLine("Salary: " + emp1.Salary);
                                Console.WriteLine("Designation: " + emp1.Designation);
                                Console.WriteLine("Department: " + emp1.Dept);
                                Console.WriteLine();
                            }

                            Console.WriteLine();
                            break;
                        }
                }
            } while (choice != 0);

        }
    }
}
