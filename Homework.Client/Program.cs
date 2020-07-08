using Newtonsoft.Json;
using System;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1 Get tax");
            Console.WriteLine("2 Add tax");
            Console.WriteLine("3 Upload file");

            string key = Console.ReadLine();

            switch (key)
            {
                case "1":
                    GetTax();
                    break;
                case "2":
                    AddTax();
                    break;
                case "3":
                    UploadFile();
                    break;
            }

            Console.WriteLine("Enter to exit");
            Console.ReadLine();
        }

        private static void GetTax()
        {
            Console.WriteLine("Enter manicipality");
            var manicipality = Console.ReadLine();
            Console.WriteLine("Enter date(yyyy-mm-dd)");
            var date = Console.ReadLine();

            var httpClient = new HttpClient();

            var content = new StringContent(JsonConvert.SerializeObject(new
            {
                manicipality,
                date
            }), Encoding.UTF8, "application/json");

            var response = httpClient.PostAsync("https://localhost:44385/api/tax/gettax", content).Result;

            string result = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);
        }
        private static void AddTax()
        {
            Console.WriteLine("Enter manicipality");
            var manicipality = Console.ReadLine();
            Console.WriteLine("Enter start date(yyyy-mm-dd)");
            var start = Console.ReadLine();
            Console.WriteLine("Enter end date(yyyy-mm-dd)");
            var end = Console.ReadLine();
            Console.WriteLine("Enter period (yearly = 1, monthly = 2, weekly = 3, daily = 4)");
            var period = Console.ReadLine();
            Console.WriteLine("Enter rate");
            var rate = Console.ReadLine();

            var httpClient = new HttpClient();

            var content = new StringContent(JsonConvert.SerializeObject(new
            {
                manicipality,
                start,
                end,
                period = int.Parse(period),
                rate = double.Parse(rate, CultureInfo.InvariantCulture)
            }), Encoding.UTF8, "application/json");

            var response = httpClient.PostAsync("https://localhost:44385/api/tax/AddTax", content).Result;

            string result = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);
        }

        private static void UploadFile()
        {
            Console.WriteLine("Enter file path");
            var filepath = Console.ReadLine();

            var file = File.ReadAllBytes(filepath);


            var httpClient = new HttpClient();

            MultipartFormDataContent multiContent = new MultipartFormDataContent();

            var fs = File.OpenRead(filepath);
            var streamContent = new StreamContent(fs);
            var fileContent = new ByteArrayContent(streamContent.ReadAsByteArrayAsync().Result);

            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");

            multiContent.Add(fileContent, "file", Path.GetFileName(filepath));

            var response = httpClient.PostAsync("https://localhost:44385/api/manicipality/UploadTaxes", multiContent).Result;

            string result = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);
        }
    }
}
