using Assign7;
namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Date d1= new Date();
            Date d2=new Date();
            Date d3=new Date();
            d1.AcceptDate();
            d1.PrintDate();
            d2.AcceptDate();
            d2.PrintDate();
            d3 = d1 - d2;
            Console.WriteLine("The difference between two dates is: "+d3.Year);
           

            

        }
    }
}
