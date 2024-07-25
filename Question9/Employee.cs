using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign7
{
    internal class Employee:Person
    {
        public enum DepartmentType{
            DEVELOPMENT,
            MARKETING,
            NETWORKING,
            HR
            }
        private static  int _Count;
        private  int _Id;
        private double _Salary;
        private string _Designation;
        private DepartmentType _Dept;

        public Employee()
        {
            _Id=++_Count;
        }

        public Employee(double salary, string designation, DepartmentType dept)
        {
            _Id = ++_Count;
            _Salary = salary;
            _Designation = designation;
            _Dept = dept;
            
        }

        public int Id
        {
           get { return _Id; }
        }

        public double Salary
        {
            get { return _Salary; }
            set { _Salary = value; }
        }

        public string Designation
        {
            get { return _Designation; }
            set { _Designation = value; }
        }

        public DepartmentType Dept
        {
            get { return _Dept; }
            set { _Dept = value; }
        }

        public void AcceptEmployee()
        {
            AcceptPerson();

            Console.WriteLine("Enter Salary: ");
            Salary=Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Designation:");
            Designation = Console.ReadLine();
            Console.WriteLine("Enter Department: ");
            Console.WriteLine("1)Development,2)Marketing,3)Networking 4)HR");
            Dept = (DepartmentType)Convert.ToInt32(Console.ReadLine());   

        }

        public void PrintEmployee()
        {
            DisplayPerson();
            Console.WriteLine("Id"+ Id);
            Console.WriteLine("Salary" + Salary);
            Console.WriteLine("Designamtion"+ Designation);
            Console.WriteLine("Department Type: "+Dept);

        }

        public override string ToString()
        {
            return ($"{base.ToString()}  Id= {Id}+ Salary= {Salary} Desinnation= {Designation}, Department Type= {Dept}");
        }
    }
}
