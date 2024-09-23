using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Method_Examples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            beginnerMethod();

            printLocalTime();

            Console.ReadLine(); 
        }



        static void beginnerMethod()
        {
            Console.WriteLine($"You are printing from a method, and have successfully exceuted {System.Reflection.MethodBase.GetCurrentMethod().Name}!");
        }
        
        static void printLocalTime()
        {
            Console.WriteLine($"You are printing from a method, and have successfully exceuted {System.Reflection.MethodBase.GetCurrentMethod().Name}!");
            string currentDateAndTime = DateTime.Now.ToString();
            Console.WriteLine($"The local time is {currentDateAndTime}");
        }
        
        static string printUserInput()
        {
            Console.WriteLine($"You are printing from a method, and have successfully exceuted {System.Reflection.MethodBase.GetCurrentMethod().Name}!");
            string userInput = Console.ReadLine();
            return $"The local time is {userInput }";
        }

        static int ageInTwentyYears(int age)
        {

            return age + 20;

        }









    }
}
