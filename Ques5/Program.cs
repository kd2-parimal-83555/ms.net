using Ques4;
using System.Diagnostics.Tracing;


namespace Ques5
{
    internal class Program
    {

        static Student[] student;

         static void createArray()
        {
            int n;
            Console.WriteLine("Enter the number of Students");
            n = Convert.ToInt32(Console.ReadLine());
            student = new Student[n];
        }
        
        static void Acceptinfo()
        {
            for (int i = 0; i < student.Length; i++)
            {
                student[i] = new Student();
                student[i].acceptDetails();
            }
        }

        static void PrintInfo() {
            for(int i=0;i < student.Length; i++)
            {
                student[i].printDetails();
            }
        }
        static void ReversedArray()
        {
            Student[] reversedArray = new Student[student.Length];
            for(int i = 0 ; i < student.Length ; i++)
            {
                reversedArray[i] = student[student.Length -i -1];
            }
            student = reversedArray;
        }

        static void Main(string[] args)
        {

            createArray();
            
            Acceptinfo();
            PrintInfo();
            ReversedArray();
            PrintInfo() ;
        }
    }
}
