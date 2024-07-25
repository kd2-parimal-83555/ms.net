
using Microsoft.VisualBasic;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Ques7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person();

            p.acceptData();
            Console.WriteLine(p);

        }
    }
   
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


        public Person(string name, bool gender, Date date , string address) { 
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
}
