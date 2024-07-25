using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment_20
{
    [Serializable]
    public class Company
    {
        public event EmployeeChange FinaceReCheck;
        private string name;
        private string address;
        private ArrayList empList;
        private double salaryExpense;

        public double SalaryExpense
        {
            get { return salaryExpense; }
            set { salaryExpense = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public Company()
        {
            empList = new ArrayList();
        }
        public void Accept()
        {
            Console.WriteLine("## Company Accept ###");
            Console.WriteLine("Enter Company Name:");
            Name = Console.ReadLine();
            Console.WriteLine("Enter Address:");
            Address = Console.ReadLine();
        }
        public void Print()
        {
            Console.WriteLine("## Company Print ###");
            Console.WriteLine("Company Name:" + Name);
            Console.WriteLine("Company Address:" + Address);
            Console.WriteLine("Company Employees:");
            PrintEmployees();
            Console.WriteLine("Salary Expenses:" + SalaryExpense);

        }
        public void CalculateSalaryExpense()
        {
            salaryExpense = 0;
            foreach (Employee emp in empList)
            {
                salaryExpense += emp.Salary;
            }
        }

        public void AddEmployee(Employee e)
        {
            e.Accept();
            empList.Add(e);
            Console.WriteLine("Re-Calculation Event Fired");
            FinaceReCheck();
        }
        public bool RemoveEmployee(int id)
        {
            foreach (Employee emp in empList)
            {
                if (emp.Id == id)
                {
                    empList.Remove(emp);
                    Console.WriteLine("Employee Removed");
                    Console.WriteLine("Re-Calculation Event Fired");
                    FinaceReCheck();
                    return true;
                }
            }
            return false;
        }
        public LinkedListNode<Employee> FindEmployee(int id)
        {
            LinkedListNode<Employee> emps = new LinkedListNode<Employee>(new Employee());
            foreach (Employee emp in empList)
            {
                if (emp.Id == id)
                {
                    emps.Value = emp;
                    return emps;
                }
            }
            return null;
        }
        public void PrintEmployees()
        {
            foreach (Employee emp in empList)
            {
                emp.Print();
            }
        }

        public override string ToString()
        {
            return "Name:" + Name + ",Address:" + Address + " ,Employee List:" + empList + " ,Salary Expenses:" + salaryExpense;
        }

    }



}
