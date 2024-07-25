using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Assign7
{
    internal class Date
    {
        private int _Day;
        private int _Month;
        private int _Year;

        public Date(){
            _Day = 1;
            _Month = 1;
            _Year = 2000;
         }

        public Date(int day, int month, int year)
        {
            _Day = day;
            _Month = month;
            _Year = year;
           
        }

        public int Day
        {
            get { return _Day; }
            set { _Day = value; }
        }
        public int Month
        {
            get { return _Month; }
            set { _Month = value; }
        }
        public int Year
        {
            get { return _Year; }
            set { _Year = value; }
        }

        public void AcceptDate()
        {
            Console.WriteLine("Enter Day: ");
            Day = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Month: ");
            Month = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Year: ");
            Year = Convert.ToInt32(Console.ReadLine());


        }
        public void PrintDate()
        {
            if(IsValid())
            {
                Console.WriteLine("Date: " + Day + " / " + Month + " / " + Year);
            }
            else
            {
                Console.WriteLine("Invalid Date");
            }
        }

        public bool IsValid()
        {
            if(Year>1900 && Year<2100)
            {
                if(Month==1 || Month == 3 || Month == 5 || Month == 7 || Month == 8 || Month == 10 || Month == 12 )
                {
                    if(_Day>0 && Day<32)
                    {
                        return true;
                    }
                }
                else if(Month == 4 || Month == 6 || Month == 9 || Month == 11)
                {

                    if (Day > 0 && Day < 31)
                    {
                        return true;
                    }

                }
                else if(Month==2)
                {
                    if(Day> 0 && Day < 29) { 
                    return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            return false;
        }

        public override string ToString()
        {
            return "Date" +Day+"/"+Month+"/"+Year;
        }

        public static int operator - (Date d1, Date d2)
        {
            Date d3 = new Date();
            if (d1.Year > d2.Year)
            {
                d3.Year = d1.Year - d2.Year;
            }
            else
            {
                d3.Year = d2.Year - d1.Year;
            }

            return d3.Year;

        }


    }
}
