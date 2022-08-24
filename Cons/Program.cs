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
            List<string> ipAddress = new List<string>();

            try
            {
                foreach (string line in System.IO.File.ReadLines(@"C:\Program Files\Inner Range\addreses.txt"))
                {
                    ipAddress.Add(line);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.Message);
            }

            if (args.Length == 0)
            {
                Console.WriteLine("Нет аргументов");
                try
                {
                    foreach (string line in System.IO.File.ReadLines(@"C:\Program Files\Inner Range\addreses.txt"))
                    {
                        ipAddress.Add(line);
                        Console.WriteLine(line);
                    }
                    Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: {0}", e.Message);
                }
            }
            else
            {
                foreach (string s in args)
                {
                    message += $"{s} ";
                }

                foreach (string ip in ipAddress)
                {
                    new Thread(() => send(10500, ip, message)).Start();
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
    }
}
