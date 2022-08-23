using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Sockets;

namespace Cons
{
    class Program
    {
        static void Main(string[] args)
        {
            
            String message = "";
            Console.WriteLine("Программа печатает входыне аргументы");
            List<string> ipAddress = new List<string>()
            {
                "192.168.0.173",
                "192.168.0.221",
                "192.168.0.204"
            };
            
            foreach (string line in System.IO.File.ReadLines(@"/Users/ivankostuhin/Projects/Thread_and_open/Thread_and_open/addreses.txt"))
            {
                ipAdd.Add(line);
            }
            
            List<object> threadMessage = new List<object>();

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

                foreach(string ip in ipAddress)
                {
                    send(10500, ip, message);
                }
            }
        }
 
        static void send(int port, string server, string message)
        {
            try
            {
                TcpClient client = new TcpClient();
                client.Connect(server, port);

                byte[] data = Encoding.UTF8.GetBytes(message);


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
        
        static void ip(List<string> ipAddress)
        {
            List<string> info = new List<string>()
            {
                "hello ",
                "red ",
                "led"
            };

            String message = "";

            foreach (string s in info)
            {
                message += $"{s} ";
            }

            foreach (string ip in ipAddress)
            {
                new Thread(() => Console.WriteLine($"Send to {10500} : {ip} {message}")).Start();
            }
        }
    }
}
