using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Assign7
{
    internal class Person
    {
        private string _Name;
        private bool _Gender;
        private Date _Birth;
        private string _Address;

        public Person() {
            _Birth = new Date();
        }

        public Person(string name,bool gender,string address,int day,int month,int year)
        {
            _Name= name;
            _Gender=gender;
            _Address=address;
            _Birth= new Date();
            
        }

        

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

    public bool Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        }
    public Date Age
        {
            get { return _Birth; }
            set { _Birth = value; }
        }

    public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
        public Date Birth
        {
                get{ return _Birth; }
                set{ _Birth = value; }
            }


            public  void AcceptPerson()
        {
            Console.WriteLine("Enter Name: ");
            Name = Console.ReadLine();

            Console.WriteLine(" Gender(True for male: False for women: )");
            Gender=Convert.ToBoolean(Console.ReadLine());

            Console.WriteLine("Enter Birth Date: ");
            _Birth.AcceptDate();

            Console.WriteLine("Enter Address: ");
            Address = Console.ReadLine();

        }

    public void DisplayPerson()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Gender: " + Gender);
            Console.WriteLine("Birth: " + _Birth.ToString());
            Console.WriteLine("Address: " + Address);

        }

        public void CalculateDate()
        {
           
            Date d1 = new Date();
            d1 = Birth;
            Console.WriteLine("Enter Current date");
            Date d2 = new Date();
            d2.AcceptDate();


            Console.WriteLine( d1 - d2);
        }



    }
}
