/*
Create a static SMath class using Sum, Subtract, Multiply, Divide methods. Call
these methods from Main() function using uni-cast delegates as well as multicast
delegates.
Create another Math class using Sum, Subtract, Multiply, Divide methods as
instance methods. Call these methods from Main() function using uni-cast
delegates as well as multicast delegates.
*/

namespace Assignment_18
{

    //static class with all the static methods
    public static class SMath
    {
        public static event Func<int, int, int> Sum;
        public static event Func<int, int, int> Subtract;
        public static event Func<int, int, int> Multiply;
        public static event Func<int, int, double> Divide;

        public static int InvokeSum(int a, int b)
        {
            return Sum?.Invoke(a, b) ?? 0;
        }

        public static int InvokeSubtract(int a, int b)
        {
            return Subtract?.Invoke(a, b) ?? 0;
        }

        public static int InvokeMultiply(int a, int b)
        {
            return Multiply?.Invoke(a, b) ?? 0;
        }

        public static double InvokeDivide(int a, int b)
        {
            return Divide?.Invoke(a, b) ?? 0;
        }
    }

    public class Math
    {
        public event Func<int, int, int> Sum;
        public event Func<int, int, int> Subtract;
        public event Func<int, int, int> Multiply;
        public event Func<int, int, double> Divide;

        public int InvokeSum(int a, int b)
        {
            return Sum?.Invoke(a, b) ?? 0;
        }

        public int InvokeSubtract(int a, int b)
        {
            return Subtract?.Invoke(a, b) ?? 0;
        }

        public int InvokeMultiply(int a, int b)
        {
            return Multiply?.Invoke(a, b) ?? 0;
        }

        public double InvokeDivide(int a, int b)
        {
            return Divide?.Invoke(a, b) ?? 0;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Static SMath class with methods as uni-cast delegates
            SMath.Sum += (a, b) => a + b;
            SMath.Subtract += (a, b) => a - b;
            SMath.Multiply += (a, b) => a * b;
            SMath.Divide += (a, b) => a / b;

            Console.WriteLine("Static SMath class results:");
            Console.WriteLine($"Sum: {SMath.InvokeSum(5, 3)}");
            Console.WriteLine($"Subtract: {SMath.InvokeSubtract(5, 3)}");
            Console.WriteLine($"Multiply: {SMath.InvokeMultiply(5, 3)}");
            Console.WriteLine($"Divide: {SMath.InvokeDivide(5, 3)}");

            // Math class with methods as instance methods
            Math math = new Math();
            math.Sum += (a, b) => a + b;
            math.Subtract += (a, b) => a - b;
            math.Multiply += (a, b) => a * b;
            math.Divide += (a, b) => a / b;

            Console.WriteLine("\nMath class results:");
            Console.WriteLine($"Sum: {math.InvokeSum(5, 3)}");
            Console.WriteLine($"Subtract: {math.InvokeSubtract(5, 3)}");
            Console.WriteLine($"Multiply: {math.InvokeMultiply(5, 3)}");
            Console.WriteLine($"Divide: {math.InvokeDivide(5, 3)}");
        }
    }

}
