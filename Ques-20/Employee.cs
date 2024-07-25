using System;

namespace Assignment_20
{
    [Serializable]
    public class Employee : Person
    {
        private static int autogen = 1;
        private int id;
        private double salary;
        private string designation;
        public enum DepartmentType
        {
            Sales,
            Development,
            HR
        }
        private DepartmentType dept;

        public DepartmentType Dept
        {
            get { return dept; }
            set { dept = value; }
        }

        public string Designation
        {
            get { return designation; }
            set { designation = value; }
        }

        public double Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public Employee()
        {
            id = autogen++;
        }
        public virtual void Accept()
        {
            base.Accept();
            Console.WriteLine("Enter Salary:");
            Salary = Convert.ToDouble(Console.ReadLine());
            Designation = "Wage";
            Console.WriteLine("Enter Department (1:Sales,2:Dev,3:HR):");
            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1)
                Dept = DepartmentType.Sales;
            else if (choice == 2)
                Dept = DepartmentType.Development;
            else
                Dept = DepartmentType.HR;

        }
        public virtual void Print()
        {
            Console.WriteLine("ID:" + id);
            base.Print();
            Console.WriteLine("Salary: " + Salary);
            Console.WriteLine("Designation: " + Designation);
            Console.WriteLine("Department: " + Dept.ToString());
        }

        public override string ToString()
        {
            return "ID:" + id + " " + base.ToString() + " ,Salary:" + Salary + " ,Designation:" + Designation + " ,Department:" + Dept.ToString();
        }
    }
}
