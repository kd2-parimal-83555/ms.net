using System;
namespace Assignment_20
{
    [Serializable]
    public class Date
    {
        private int day;
        private int month;
        private int year;

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public int Month
        {
            get { return month; }
            set { month = value; }
        }

        public int Day
        {
            get { return day; }
            set { day = value; }
        }
        public Date()
        {
            Day = 1;
            Month = 1;
            Year = 1980;
        }
        public Date(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }
        public void AcceptDate()
        {
            Console.WriteLine("Enter Day:");
            Day = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Month:");
            Month = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Year:");
            Year = Convert.ToInt32(Console.ReadLine());
        }
        public void PrintDate()
        {
            Console.WriteLine("Day:" + Day);
            Console.WriteLine("Month:" + Month);
            Console.WriteLine("Year:" + Year);
        }
        public override string ToString()
        {
            return Day+"/"+Month+"/"+Year;

        }
        public bool IsValid()
        {
            if (Year < 0)
            {
                return false;
            }
            if (Month < 0 && Month > 12)
            {
                return false;
            }
            if (Day < 0 || Day > 31)
            {
                return false;
            }
            if (Month == 2)
            {
                if (Day > 29)
                {
                    return false;
                }
            }
            if (Month == 4 || Month == 6 || Month == 9 || Month == 11)
            {
                if (Day > 30)
                {
                    return false;
                }
            }
            return true;
        }
        public static int YearDiff(Date d1, Date d2)
        {
            return Math.Abs(d1.Year - d2.Year);
        }
        public static int operator -(Date d1, Date d2)
        {
            return Math.Abs(d1.Year - d2.Year);
        }
    }
}
