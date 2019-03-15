using System;
using System.Net;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch st = new Stopwatch();

            st.Start();

            string url = "https://uinames.com/api/?ext&amount=50";

            string json = new WebClient().DownloadString(url);


            List<RootObject> data = new JavaScriptSerializer().Deserialize<List<RootObject>>(json);

            foreach (RootObject x in data)
            {
                Console.WriteLine("Name: {0} {1}\n***** Credit Card ***** \n Number: {2} \nPin: {3} \nSecurity: {4} \nExpiration {5}\n", x.name, x.surname, x.credit_card.number, x.credit_card.pin, x.credit_card.security, x.credit_card.expiration);

            }

            st.Stop();

            Console.WriteLine("Time to populate the list: {0}ms\n", st.ElapsedMilliseconds);

            Console.ReadLine();

        }
    }
    public class Birthday
    {
        public string dmy { get; set; }
        public string mdy { get; set; }
        public int raw { get; set; }
    }

    public class CreditCard
    {
        public string expiration { get; set; }
        public string number { get; set; }
        public int pin { get; set; }
        public int security { get; set; }
    }

    public class RootObject
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string gender { get; set; }
        public string region { get; set; }
        public int age { get; set; }
        public string title { get; set; }
        public string phone { get; set; }
        public Birthday birthday { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public CreditCard credit_card { get; set; }
        public string photo { get; set; }
    }
}
    

