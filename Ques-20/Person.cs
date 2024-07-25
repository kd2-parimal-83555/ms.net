using System;

namespace Assignment_20
{
    [Serializable]
    public class Person
    {
        private string name;
        private bool gender;
        private Date birth;
        private string address;
        private int age;

        public int Age
        {
            get { return age; }
        }

        public string Address
        {
            get { return address; }
        }

        public Date Birth
        {
            get { return birth; }
        }

        public bool Gender
        {
            get { return gender; }
        }

        public string Name
        {
            get { return name; }
        }
        public Person()
        {
            birth =new Date();
        }

        public Person(string name, bool gender, Date birth, string address)
        {
            this.name = name;
            this.gender = gender;
            this.birth = birth;
            this.address = address;
            age = birth.Year - 2024;
        }
        public virtual void Accept()
        {
            Console.WriteLine("Enter Name:");
            name = Console.ReadLine();
            Console.WriteLine("Enter Gender (Male:True,Female:false):");
            gender = Convert.ToBoolean(Console.ReadLine());
            birth.AcceptDate();
            Console.WriteLine("Enter Address:");
            address = Console.ReadLine();
            age = Birth-new Date(1,1,DateTime.Now.Year);
        }
        public virtual void Print()
        {
            Console.WriteLine("Name:" + Name);
            Console.WriteLine("Gender:" + (Gender ? "Male" : "Female"));
            Console.WriteLine("Birth:" + Birth.ToString());
            Console.WriteLine("Address:" + Address);
            Console.WriteLine("Age:" + Age);
        }
        public override string ToString()
        {
            return "Name:" + Name + " ,Gender:" + (Gender ? "Male" : "Female") + " ,Birth:" + Birth.ToString() + " ,Address:" + address;
        }

    }
}
