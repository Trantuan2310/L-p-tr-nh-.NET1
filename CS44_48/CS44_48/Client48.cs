using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client48
{
    class Client48
    {
        public static async Task Run()
        {
            using (TcpClient client = new TcpClient("127.0.0.1", 5000))
            {
                Console.WriteLine("Connected to server.");
                NetworkStream stream = client.GetStream();

                while (true)
                {
                    Console.Write("Enter command (time/exit): ");
                    string message = Console.ReadLine();

                    if (message.ToLower() == "exit")
                    {
                        byte[] exitBytes = Encoding.UTF8.GetBytes(message);
                        stream.Write(exitBytes, 0, exitBytes.Length);
                        Console.WriteLine("Exiting...");
                        break;
                    }
                    else if (message.ToLower() == "time")
                    {
                        byte[] timeBytes = Encoding.UTF8.GetBytes(message);
                        stream.Write(timeBytes, 0, timeBytes.Length);

                        byte[] buffer = new byte[1024];
                        int bytesRead = stream.Read(buffer, 0, buffer.Length);
                        string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                        Console.WriteLine("Server response: " + response);
                    }
                    else
                    {
                        Console.WriteLine("Invalid command. Please enter 'time' or 'exit'.");
                    }
                }
            }            
        }
    }
}