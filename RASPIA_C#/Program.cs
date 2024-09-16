using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;

//using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace RASPIA_C_
{
    class Main_API
    {
        public Main_API()
        {
        }
        public string[] cleanUserInput(params string[] input)
        {
            //make user output http request friendly
            return input.Where(element => { if (element != null)
                    { return true; }
                else
                { return false; } })
                .Select(element => Uri.EscapeDataString(element)).ToArray();
            
        }

        public void createRequest(string output)
        {


        }


        public void callAPI(string output)
        {


        }
        public void requestAndDecodeResponse(string output)
        {


        }


    }
    internal class Program
    {
        static void Main(string[] args)
        {
           Main_API api = new Main_API();

            string[] answers = new string[24];
            answers[0] = "Soon T M";
            answers[1] = "edgar//3\\";



            string[] test =api.cleanUserInput(answers);
            foreach (string input in test)
            {
                Console.WriteLine(input);
            }
            Console.ReadKey();
        }

        
    }
}
