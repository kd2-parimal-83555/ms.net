using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace EmployeeLib_Framework_Serialize
{

    #region Assignment-6

    //class Date from Assignment-6
    [Serializable]
    public class Date
    {

        private int _day;
        private int _month;
        private int _year;

        public int Day
        {
            get { return _day; }
            set
            {
                //accepting the date only it is between 1 and 31
                if (value < 1 || value > 31)
                    throw new Exception("Invalid day");
                _day = value;
            }
        }

        public int Month
        {
            get { return _month; }
            set
            {
                //accepting the month only it is between 1 and 12
                if (value < 1 || value > 12)
                    throw new Exception("Invalid month");
                _month = value;
            }
        }

        public int Year
        {
            get { return _year; }

            //accepting the year only it is greater than 1
            set
            {
                if (value < 1)
                    throw new Exception("Invalid year");
                _year = value;
            }
        }


        // Default constructor
        public Date()
        {
            Day = 1;
            Month = 1;
            Year = 1;
        }

        // Parameterized constructor
        public Date(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }

        // AcceptDate() method
        public void AcceptDate()
        {
            Console.WriteLine("Enter Day");
            this.Day = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Month");
            this.Month = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Year");
            this.Year = Convert.ToInt32(Console.ReadLine());
        }


        // PrintDate() method
        public void PrintDate()
        {
            Console.WriteLine("Date: " + Day + "/" + Month + "/" + Year);
        }

        public bool IsValid()
        {
            if (Day < 1 || Day > 31 || Month < 1 || Month > 12)
                return false;

            // Array to store number of days in each month
            int[] daysInMonth = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

            if (Month == 2)
            {
                // Check for leap year, no of days in feb will be 29 if it is a leap year
                // or 28 if it is not a leap year
                if ((Year % 4 == 0 && Year % 100 != 0) || Year % 400 == 0)
                    daysInMonth[2] = 29;
                else
                    daysInMonth[2] = 28;
            }

            return Day <= daysInMonth[Month];
        }

        public override string ToString()
        {
            return Day + "/" + Month + "/" + Year;
        }

        // Static member function to calculate difference in years
        public static int CalculateYearsDifference(Date date1, Date date2)
        {
            int yearsDifference = date2.Year - date1.Year;

            if (date1.Month > date2.Month || (date1.Month == date2.Month && date1.Day > date2.Day))
                yearsDifference--;

            return yearsDifference;
        }

        // Overloading "-" operator
        public static Date operator -(Date date1, Date date2)
        {
            int yearsDifference = Date.CalculateYearsDifference(date1, date2);
            return new Date(1, 1, yearsDifference);
        }

        public static int AgeCalculator(Date birthDate)
        {
            int yearsDifference = Date.CalculateYearsDifference(birthDate, new Date(20, 5, 2024));
            return yearsDifference;
        }
    }

    #endregion

    #region Assignment-7

    //class Person from Assignment-7
    [Serializable]
    public class Person
    {
        private string _name;
        private bool _gender;
        private Date _birth;
        private string _address;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public bool Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        public Date Birth
        {
            get { return _birth; }
            set
            {
                if (!value.IsValid())
                    throw new Exception("Invalid birth date");
                _birth = value;
            }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public int Age
        {
            get
            {
                int yearsDifference = Date.AgeCalculator(_birth);
                return yearsDifference;
            }
        }

        public Person()
        {
            this._name = "";
            this._gender = false;
            this._birth = new Date();
            this._address = "";
        }

        public Person(string name, bool gender, Date birth, string address)
        {
            this._name = name;
            this._gender = gender;
            this._birth = birth;
            this._address = address;
        }

        public void Accept()
        {
            Console.WriteLine("Enter name: ");
            this._name = Console.ReadLine();

            Console.WriteLine("Enter gender (true for Male, false for Female): ");
            this._gender = Convert.ToBoolean(Console.ReadLine());

            Console.WriteLine("Enter date of birth (dd mm yyyy): ");
            this._birth.AcceptDate();

            Console.WriteLine("Enter address: ");
            this._address = Console.ReadLine();
        }

        public void Print()
        {
            Console.WriteLine("Name: " + _name);
            Console.WriteLine("Gender: " + (_gender ? "Male" : "Female"));
            Console.WriteLine("Birth Date: " + _birth.ToString());
            Console.WriteLine("Address: " + _address);
        }

        public override string ToString()
        {
            return _name + ", " + (_gender ? "Male" : "Female") + ", " + _birth.ToString() + ", " + _address;
        }
    }

    #endregion

    #region Assignment-8


    //class Employee from Assignment-8
    [Serializable]
    public enum DepartmentType
    {
        //various departments in the company
        HR = 1,
        IT = 2,
        Finance = 3,
        Marketing = 4
    }

    [Serializable]
    public class Counter
    {
        private static int count = 0;

        private Counter()
        {

        }

        public static int GetCount()
        {
            count = count + 1;
            return count;
        }
    }

    [Serializable]
    public class Employee : Person
    {
        //static field for auto generating id
        private int id;
        private double salary;
        private string designation;
        private DepartmentType dept;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public double Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        public string Designation
        {
            get { return designation; }
            set { designation = value; }
        }

        public DepartmentType Dept
        {
            get { return dept; }
            set { dept = value; }
        }

        public Employee()
        {
            // id++;
            this.Id = Counter.GetCount();
        }

        public Employee(double salary, string designation, DepartmentType dept) : this()
        {
            this.salary = salary;
            this.designation = designation;
            this.dept = dept;

        }

        public Employee(double salary, DepartmentType dept, string designation)
        {
            this.salary = salary;
            this.designation = designation;
            this.dept = dept;
            this.Id = Counter.GetCount();
        }

        public virtual void Accept()
        {
            Console.WriteLine("Enter salary: ");
            try
            {
                salary = Convert.ToDouble(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("Enter salary only in numbers");
                throw;
            }

            Console.WriteLine("Enter designation: ");
            designation = Console.ReadLine();
            Console.WriteLine("Enter department: ");
            Console.WriteLine("HR = 1");
            Console.WriteLine("IT = 2");
            Console.WriteLine("Finance = 3");
            Console.WriteLine("Marketing = 4");
            dept = (DepartmentType)Convert.ToInt32(Console.ReadLine());
        }

        public virtual void Print()
        {
            Console.WriteLine("ID: " + id);
            Console.WriteLine("Salary: " + salary);
            Console.WriteLine("Designation: " + designation);
            Console.WriteLine("Department: " + dept);
        }

        public override string ToString()
        {
            return "ID: " + id + "\nSalary: " + salary + "\nDesignation: " + designation + "\nDepartment: " + dept;
        }

        /*// Serialize the Employee object
        public void Serialize(string filename)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(fs, this);
            }
        }

        // Deserialize the Employee object
        public static Employee Deserialize(string filename)
        {
            if (File.Exists(filename))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    return (Employee)formatter.Deserialize(fs);
                }
            }
            else
            {
                throw new FileNotFoundException("The specified file does not exist.");
            }
        }*/

    }

    #endregion

    #region Assignment-9

    [Serializable]
    //class Manager from Assignment-9
    public class Manager : Employee
    {
        private double bonus;

        public double Bonus
        {
            get { return bonus; }
            set { bonus = value; }
        }

        //defualt constructor
        public Manager()
        {
            Designation = "Manager";
        }

        //parameterized constructor
        public Manager(double bonus)
        {
            Designation = "Manager";
            Bonus = bonus;
        }

        //override the Accept method of base class in which the designation is fixed as "Manager"
        public override void Accept()
        {
            Console.WriteLine("Enter salary: ");
            Salary = Convert.ToDouble(Console.ReadLine());
            Designation = "Manager";
            Console.WriteLine("Enter department: ");
            Console.WriteLine("HR = 1");
            Console.WriteLine("IT = 2");
            Console.WriteLine("Finance = 3");
            Console.WriteLine("Marketing = 4");
            Dept = (DepartmentType)Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Bonus: ");
            Bonus = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine();
        }

        public override void Print()
        {
            Console.WriteLine("ID: " + Id);
            Console.WriteLine("Salary: " + Salary);
            Console.WriteLine("Designation: " + Designation);
            Console.WriteLine("Department: " + Dept);
            Console.WriteLine("Bonus: " + Bonus);
            Console.WriteLine();
        }

        public override string ToString()
        {
            return base.ToString() + "Bonus: " + Bonus;
        }
    }

    #endregion

    #region Assignment-10

    [Serializable]
    //class Supervisor from Assignment-10
    public class Supervisor : Employee
    {
        private int subbordinates;

        public int Subbordinates
        {
            get { return subbordinates; }
            set { subbordinates = value; }
        }

        //default constructor
        public Supervisor()
        {
            Designation = "Supervisor";
        }

        //parameterized constructor
        public Supervisor(int subbordinates)
        {
            Designation = "Supervisor";
            Subbordinates = subbordinates;
        }

        //override the Accept method of base class in which the designation is fixed as "Supervisor"
        public override void Accept()
        {
            Console.WriteLine("Enter salary: ");
            Salary = Convert.ToDouble(Console.ReadLine());
            Designation = "Supervisor";
            Console.WriteLine("Enter department: ");
            Console.WriteLine("HR = 1");
            Console.WriteLine("IT = 2");
            Console.WriteLine("Finance = 3");
            Console.WriteLine("Marketing = 4");
            Dept = (DepartmentType)Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Number of Subbordinates: ");
            Subbordinates = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
        }

        public override void Print()
        {
            Console.WriteLine("ID: " + Id);
            Console.WriteLine("Salary: " + Salary);
            Console.WriteLine("Designation: " + Designation);
            Console.WriteLine("Department: " + Dept);
            Console.WriteLine("Number of Subbordinates: " + Subbordinates);
            Console.WriteLine();
        }
    }

    #endregion

    #region Assignment-11

    [Serializable]
    //class WageEmp from Assignment-11
    public class WageEmp : Employee
    {
        private int hours;
        private int rate;

        public int Hours
        {
            get { return hours; }
            set { hours = value; }
        }

        public int Rate
        {
            get { return rate; }
            set { rate = value; }
        }

        //default constructor
        public WageEmp()
        {
            Designation = "Wage";
        }

        //parameterized constructor
        public WageEmp(int hours, int rate)
        {
            Designation = "Wage";
            Hours = hours;
            Rate = rate;
        }

        //override the Accept method of base class in which the designation is fixed as "Wage"
        public override void Accept()
        {
            Console.WriteLine("Enter salary: ");
            Salary = Convert.ToDouble(Console.ReadLine());
            Designation = "Wage";
            Console.WriteLine("Enter department: ");
            Console.WriteLine("HR = 1");
            Console.WriteLine("IT = 2");
            Console.WriteLine("Finance = 3");
            Console.WriteLine("Marketing = 4");
            Dept = (DepartmentType)Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Number of Hours: ");
            Hours = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Rate: ");
            Rate = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
        }

        public override void Print()
        {
            Console.WriteLine("ID: " + Id);
            Console.WriteLine("Salary: " + Salary);
            Console.WriteLine("Designation: " + Designation);
            Console.WriteLine("Department: " + Dept);
            Console.WriteLine("Hours: " + Hours);
            Console.WriteLine("Rate: " + Rate);
            Console.WriteLine("Earned income : Rs " + hours * rate);
            Console.WriteLine();
        }
    }

    #endregion

    #region Assignment-12

    [Serializable]
    //class Program from Assignment-12
    public class Company
    {
        private string _name;
        private string _address;
        private ArrayList _empList;
        private double _salaryExpense;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public ArrayList EmpList
        {
            get { return _empList; }
            set { _empList = value; }
        }

        public double SalaryExpense
        {
            get { return _salaryExpense; }
            set { _salaryExpense = value; }
        }

        //default constructor
        public Company()
        {
            this._empList = new ArrayList();
        }

        //parameterized constructor
        public Company(string name, string address, ArrayList empList)
        {
            this._name = name;
            this._address = address;
            this._empList = empList;

        }

        public Company(string name, string address)
        {
            this._name = name;
            this._address = address;

        }

        public void Accept()
        {
            Console.WriteLine("Enter Company Name: ");
            Name = Console.ReadLine();
            Console.WriteLine("Enter Company Address: ");
            Address = Console.ReadLine();
            Console.WriteLine();
        }

        public void Print()
        {
            Console.WriteLine("Company Name: " + Name);
            Console.WriteLine("Company Address: " + Address);
            Console.WriteLine();
        }

        public void CalculateSalaryExpense()
        {
            double total = 0;
            foreach (Employee e in _empList)
            {
                total += e.Salary;
            }

            SalaryExpense = total;
        }

        public void AddEmployee(Employee e)
        {
            this._empList.Add(e);
        }

        public bool RemoveEmployee(int id)
        {
            Employee node = FindEmployee(id);
            if (node != null)
            {
                this._empList.Remove(node);
                return true;
            }

            return false;
        }

        public Employee FindEmployee(int id)
        {
            foreach (Employee e in _empList)
            {
                if (e.Id == id)
                {
                    return e;
                }
            }

            return null;
        }

        public override string ToString()
        {
            return "Company Name: " + Name + "\nCompany Address: " + Address + "\nSalary Expense: " + SalaryExpense;
        }

        public void PrintEmployees()
        {
            foreach (Employee e in _empList)
            {
                Console.WriteLine(e);
            }
        }
    }
}

#endregion

