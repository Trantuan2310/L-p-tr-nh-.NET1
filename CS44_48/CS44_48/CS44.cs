using System.Net;
using System.Net.NetworkInformation;

namespace CS44
{
    class Program44
    {
        public static void Run()
        {
// RUN PHASE 1 URI
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("RUN PHASE 1 URI");
            Console.ResetColor();

            string url = "https://www.vidu.com/laptrinh/to/csharp/?page=3#section3";
            var uri = new Uri(url);
            var uritype = typeof(Uri);
            uritype.GetProperties().ToList().ForEach(property =>
            {
                Console.WriteLine($"{property.Name,15} {property.GetValue(uri)}");
            });
            // Trả về 1 mảng chứa d=các đoạn đường dẫn của uri
            Console.WriteLine($"Segments: {string.Join(",", uri.Segments)}");
// RUN PHASE 1 URI

// RUN PHASE 2 DNS
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("RUN PHASE 2 DNS");
            Console.ResetColor();

            // sử dụng lớp Dns để lấy thông tin của host từ URL
            var hostEntry = Dns.GetHostEntry(uri.Host);
            Console.WriteLine($"Host {uri.Host} co cac IP:");
            // hostEntry.AddressList là một mảng chứa các địa chỉ IP mà host có thể liên kết.
            hostEntry.AddressList.ToList().ForEach(ip => Console.WriteLine(ip));
// RUN PHASE 2 DNS

// RUN PHASE 3 PING
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("RUN PHASE 3 PING");
            Console.ResetColor();

            var ping = new Ping();
            var pingReply = ping.Send("google.com.vn");
            if (pingReply.Status == IPStatus.Success)
            {
                Console.WriteLine($"Status: {pingReply.Status}");
                Console.WriteLine($"Time: {pingReply.RoundtripTime}ms");
                Console.WriteLine($"Address IP: {pingReply.Address}");
            }
            else
            {
                Console.WriteLine($"Status: {pingReply.Status}");
                Console.WriteLine($"Time: {pingReply.RoundtripTime}ms");
                Console.WriteLine($"Address IP: {pingReply.Address}");
            }
        }
    }
}