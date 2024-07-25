/*Modify EmployeeLib assembly to provide serialization support. Change the
version number of this assembly and re-deploy it into GAC. In menu driven
console application add two menus for serialization and deserialization. Use
BinaryFormatter class.*/

using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Assignment_16;
using EmployeeLib_Framework;

namespace Assignment_16
{
    public class SerializeUtility
    {
        public static void Serialize(Employee emp, string filename)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write))
            {
                formatter.Serialize(fs, emp);
            }
        }

        public static Employee Deserialize(string filename)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                return (Employee)formatter.Deserialize(fs);
            }
        }
    }
}

internal class Program
{
    static void Main(string[] args)
    {

        Employee emp = new Employee(15000, DepartmentType.IT, "Technical Lead");

        string filename = "E:\\SunBeam-Assigment\\DotNet\\DotNet-Assignments\\Assignment-16\\SerializeObject\\employee.txt";

        // Menu-driven console application
        while (true)
        {
            Console.WriteLine("\n1. Serialize Employee");
            Console.WriteLine("2. Deserialize Employee");
            Console.WriteLine("0. Exit");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    SerializeUtility.Serialize(emp, filename);
                    Console.WriteLine("Employee serialized successfully.");
                    break;
                case 2:
                    Employee deserializedEmp = SerializeUtility.Deserialize(filename);
                    Console.WriteLine("Id: " + deserializedEmp.Id);
                    Console.WriteLine("Salary: " + deserializedEmp.Salary);
                    Console.WriteLine("Designation: " + deserializedEmp.Designation);
                    Console.WriteLine("Department: " + deserializedEmp.Dept);
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

    }
}


