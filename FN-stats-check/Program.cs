using System;
using System.IO;
using System.Net;

namespace FN_stats_check
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fortnite Stats Checker\n  [1] - PC\n  [2] - PS4\n  [3] - XBOX\nSelect a Platform");
            string platform = Console.ReadLine();
            if (platform == "1")
            {
                platform = "pc";
            }
            else if (platform == "2")
            {
                platform = "psn";
            }
            else if (platform == "3")
            {
                platform = "xbl";
            }
            else
            {
                Console.WriteLine("error occured!");
                Console.ReadKey();
            }
            Console.WriteLine("Please enter your name:  ");
            String name = Console.ReadLine();
            String url = "https://api.fortnitetracker.com/v1/profile/";
            WebRequest request = WebRequest.Create(url + platform + "/" + name);
            request.Headers["TRN-Api-Key"] = "645abfec-b213-4c4e-9b6c-9ced206e1dec";
            WebResponse response = request.GetResponse();
            Console.WriteLine(response);
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            Console.Write(responseFromServer);
            reader.Close();
            response.Close();

        }
    }
}
