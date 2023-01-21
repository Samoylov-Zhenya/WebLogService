using System;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Net.Sockets;

namespace MakeAGETRequest_charp
{
    class Program
    {
        static HttpClient httpClient = new HttpClient();
        static void Main()
        {
            Console.WriteLine(GetLocalIPAddress());

            //HttpContent content = new StringContent("Hello METANIT.COM");

            //content.Headers.Add("SecreteCode", "Anything");

            //using var response = await httpClient.PostAsync("http://192.168.1.102:5178/", content);
            //string responseText = await response.Content.ReadAsStringAsync();
            //Console.WriteLine(responseText);
        }
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
    }
}