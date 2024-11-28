using System;
using System.Net.Security;
using System.Net.Sockets;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CS48
{
    class Program48
    {
        public static async Task Run()
        {
// RUN PHASE 1
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("RUN PHASE 1 TcpClient");
            Console.ResetColor();

            string url = "https://xuanthulab.net/networking-giao-thuc-tcp-voi-cac-lop-tcplistener-tcpclient-va-cac-lop-uri-ipaddress-c-c-sharp.html#tcp";
            await ReadHtmlAsync(url);
// RUN PHASE 1

// RUN PHASE 2
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("RUN PHASE 2 TcpListener");
            Console.ResetColor();

            TcpListener server = new TcpListener(IPAddress.Any, 5000);
            server.Start();
            Console.WriteLine("Server started, waiting for connection...");

            while (true)
            {
                using (TcpClient client = server.AcceptTcpClient())
                {
                    Console.WriteLine("Client connected.");
                    // tạo một luồng để đọc/ghi dữ liệu với client
                    NetworkStream stream = client.GetStream();
                    byte[] buffer = new byte[1024];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    string request = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();

                    if (request.ToLower() == "time")
                    {
                        string response = DateTime.Now.ToString();
                        byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                        stream.Write(responseBytes, 0, responseBytes.Length);
                        Console.WriteLine($"Sent time: {response}");
                    }
                    else if (request.ToLower() == "exit")
                    {
                        Console.WriteLine("Exit command received, closing connection.");
                        break;
                    }
                    else
                    {
                        string response = "Invalid command";
                        byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                        stream.Write(responseBytes, 0, responseBytes.Length);
                        Console.WriteLine("Sent invalid command response.");
                    }
                }
            }

            server.Stop();
            Console.WriteLine("Server stopped.");
// RUN PHASE 2         
        }

// PHASE 1
        // Xác thực chứng chỉ SLL 
        public static bool ValidateServerCertificate(
             object sender,
             X509Certificate certificate,
             X509Chain chain,
             SslPolicyErrors sslPolicyErrors)
        {
            Console.WriteLine("ValidateServerCertificate");
            if (sslPolicyErrors == SslPolicyErrors.None) return true;
            Console.WriteLine("Certificate error: {0}", sslPolicyErrors);

            return false;
        }

        public static async Task ReadHtmlAsync(string url)
        {

            using (var client = new TcpClient())
            {
                Console.WriteLine($"Start get {url}");
                Uri uri = new Uri(url);

                var hostAdress = await Dns.GetHostAddressesAsync(uri.Host);
                IPAddress ipaddrress = hostAdress[0];
                Console.WriteLine($"Host: {uri.Host}, \nIP: {ipaddrress}:{uri.Port}");
                await client.ConnectAsync(ipaddrress.MapToIPv4(), uri.Port);
                Console.WriteLine("Connected");
                Console.WriteLine();


                Stream stream;
                if (uri.Scheme == "https")
                {
                    stream = new SslStream(client.GetStream(), false,
                                           new RemoteCertificateValidationCallback(ValidateServerCertificate),
                                           null);
                    (stream as SslStream).AuthenticateAsClient(uri.Host);
                }
                else
                {
                    stream = client.GetStream();
                }

                Console.WriteLine($"Get Stream OK: {stream.GetType().Name}");


                StringBuilder header = new StringBuilder();
                header.Append($"GET {uri.PathAndQuery} HTTP/1.1\r\n");
                header.Append($"Host: {uri.Host}\r\n");
                header.Append($"\r\n");

                Console.WriteLine("Request:");
                Console.WriteLine(header);

                byte[] bsend = Encoding.UTF8.GetBytes(header.ToString());
                await stream.WriteAsync(bsend, 0, bsend.Length);

                await stream.FlushAsync();

                Console.WriteLine("Send Message OK");


                var ms = new MemoryStream();
                byte[] buffer = new byte[255];
                int bytes = -1;
                do
                {
                    bytes = await stream.ReadAsync(buffer, 0, buffer.Length);

                    ms.Write(buffer, 0, bytes);

                    Array.Clear(buffer, 0, buffer.Length);

                } while (bytes != 0);

                Console.WriteLine($"Read OK");

                ms.Seek(0, SeekOrigin.Begin);
                var reader = new StreamReader(ms);
                string html = reader.ReadToEnd();
                Console.WriteLine("Response:");
                Console.WriteLine(html);
            }
        }
// PHASE 1
    }
}