using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace Cons
{
    class Program
    {
        private const int port = 10500;
        private const string server = "192.168.0.173";

        static void Main(string[] args)
        {
            String message = "";
            Console.WriteLine("Программа печатает входыне аргументы");
            if (args.Length == 0)
            {
                Console.WriteLine("Нет аргументов");
            }
            else
            {
                foreach (string s in args)
                {
                    message += $"{s} ";
                }

                try
                {
                    TcpClient client = new TcpClient();
                    client.Connect(server, port);

                    byte[] data = System.Text.Encoding.UTF8.GetBytes(message);

                    StringBuilder response = new StringBuilder();
                    NetworkStream stream = client.GetStream();

                    stream.Write(data, 0, data.Length);

                    Console.WriteLine("Sent: {0}", message);

                    Console.WriteLine(response.ToString());

                    stream.Close();
                    client.Close();
                }
                catch (SocketException e)
                {
                    Console.WriteLine("SocketException: {0}", e);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: {0}", e.Message);
                }

                Console.WriteLine("Запрос завершен...");
            }
        }
    }
}
