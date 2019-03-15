using System;
using System.Net;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List_Objects
{
    class Program
    {
        static void Main(string[] args)
        {
            
           Stopwatch st = new Stopwatch();

            st.Start();

            string url = "https://uinames.com/api/?ext&amount=50";

            string json = new WebClient().DownloadString(url);

           
            List<CustomObject> data = new JavaScriptSerializer().Deserialize<List<CustomObject>>(json);
           
            foreach (CustomObject x in data)
            {
                Console.WriteLine("Name: {0} {1}\n Gender: {2}\n Region: {3}\n", x.name, x.surname, x.gender, x.region);
              
            }

            st.Stop();

            Console.WriteLine("Time to populate the list: {0}ms\n", st.ElapsedMilliseconds);

            Console.ReadLine();

        }
    }
    public class CustomObject
    {

        public string name { get; set; }
        public string surname { get; set; }
        public string gender { get; set; }
        public string region { get; set; }
        
    }
    
}
