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
            return input.Select(element => Uri.EscapeDataString(element)).ToArray();
            
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

            string[] test =api.cleanUserInput(["Soon T M","edgar//3\\"]);
            foreach (string input in test)
            {
                Console.WriteLine(input);
            }
            Console.ReadKey();
        }

        
    }
}
