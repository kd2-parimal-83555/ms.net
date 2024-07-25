namespace EmployeeLib
{

    public class Person
    {
        private string _name;
        private bool _gender;
        private Date _date;
        private string _address;
        private int _age;

        public int Age
        {
            get { return Date.calculateAge(date); }
        }


        public Person(string name, bool gender, Date date, string address)
        {
            Name = name;
            Gender = gender;
            this.date = date;
            Address = address;
        }

        public Person()
        {

        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }


        public Date date
        {
            get { return _date; }
            set { _date = value; }
        }



        public bool Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }


        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }



        public override bool Equals(object? obj)
        {
            return obj is Person person &&
                   _name == person._name &&
                   _gender == person._gender &&
                   EqualityComparer<Date>.Default.Equals(_date, person._date) &&
                   _address == person._address &&
                   Address == person.Address &&
                   EqualityComparer<Date>.Default.Equals(date, person.date) &&
                   Gender == person.Gender &&
                   Name == person.Name;
        }

        public virtual void acceptData()
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
        }


        public virtual void printData()
        {
            string genderString = Gender ? "Male" : "Female";
            Console.WriteLine($"Name: {Name}, Gender: {genderString}, BirthDate: {date}, Address: {Address}, Age: {Age}");

        }

        public override string ToString()
        {

            string genderString = Gender ? "Male" : "Female";
            return $"Name: {Name}, Gender: {genderString}, BirthDate: {date}, Address: {Address}, Age: {Age}";
        }
    }

    public class Date
    {
        private int _day;
        private int _month;
        private int _year;

        public int month
        {
            get { return _month; }
            set { _month = value; }
        }
        public int year
        {
            get { return _year; }
            set { _year = value; }
        }
        public int day
        {
            get { return _day; }
            set { _day = value; }
        }

        public Date(int day, int month, int year)
        {
            this.day = day;
            this.month = month;
            this.year = year;
        }

        public Date() { }

        public void acceptDate()
        {
            Console.WriteLine("insert day");
            day = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("insert month");
            month = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("insert year");
            year = Convert.ToInt32(Console.ReadLine());
        }

        public void printDate()
        {
            Console.WriteLine(day + "/" + month + "/" + year);
        }

        public override string ToString()
        {
            return day + "/" + month + "/" + year;
        }

        public bool isValid()
        {
            if (this.day > 31 && this.day < 1)
            {
                return false;
            }
            else if (this.month > 12 && this.month < 1)
            {
                return false;
            }
            else if (this.year > 12 && this.year < 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static int calculateAge(Date birth)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birth.year;

            if (today.Month < birth.month || (today.Month == birth.month && today.Day < birth.day))
            {
                age--;
            }

            return age;
        }

        public static int operator -(Date d1, Date d2)
        {
            return d1.year - d2.year;
        }


    }

    public class Employee : Person
    {
        private static int count = 0;
        private int _Id;
        private string _designation;
        private int _salary;
        private string _dept;

        public Employee() : base()
        {
            this.Id = ++count;
        }


        public Employee(string designation, int salary, string dept, string name, bool gender, Date date, string address) : base(name, gender, date, address)
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

    public class Manager : Employee
    {
        private double _bonus;

        public double Bonus
        {
            get { return _bonus; }
            set { _bonus = value; }
        }

        public Manager() { }

        public Manager(double bonus, string designation, int salary, string dept, string name, bool gender, Date date, string address) : base(designation, salary, dept, name, gender, date, address)
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

    public class WageEmp : Employee
    {
        private int _hours;
        private int _rate;

        public int Rate
        {
            get { return _rate; }
            set { _rate = value; }
        }


        public int Hours
        {
            get { return _hours; }
            set { _hours = value; }
        }


        public WageEmp() { }
        public WageEmp(int hours, int rate, string designation, int salary, string dept, string name, bool gender, Date date, string address) : base(designation, salary, dept, name, gender, date, address)
        {
            this.Hours = hours;
            this.Rate = rate;
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

            Console.Write("Enter Hours: ");
            Hours = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Rate: ");
            Rate = Convert.ToInt32(Console.ReadLine());

            this.Designation = "Wages";
        }

        public override string ToString()
        {
            return base.ToString() + " Hours : " + Hours + "Rate : " + Rate;
        }

        public override void printData()
        {
            base.printData();
            Console.WriteLine($" Hours : {Hours} Rate : {Rate}");
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
            set { _salaryExepense = value; }
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
            Name = Console.ReadLine();
            Console.Write("Enter Company's Address....");
            Address = Console.ReadLine();
            this.SalaryExpense = 0;

        }

        public void printData()
        {
            Console.WriteLine("Company's name : " + Name + "Company's Address : " + Address + " SalaryExpense : " + calculateSalaryExpense());
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
            double salarytotal = 0;
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
            return false;
        }

        public LinkedListNode<Employee> findEmployee(int id)
        {
            LinkedListNode<Employee> node;

            for (node = employees.First; node != null; node = node.Next)
            {
                if (node.Value.Id == id)
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
