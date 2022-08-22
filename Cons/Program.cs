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
        private const string server = "192.168.0.231";

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

                //string text = "Р—Р°РєР°Р· Р·РІРѕРЅРєР° С‚РµС…РЅРёС‡РµСЃРєРѕР№ РїРѕРґРґРµСЂР¶РєРё";
                
                //Encoding utf8 = Encoding.GetEncoding("Windows-1251");
                //Encoding win1251 = Encoding.GetEncoding("cp866");

                //byte[] utf8Bytes = win1251.GetBytes(message);
                //byte[] win1251Bytes = Encoding.Convert(utf8, win1251, utf8Bytes);
                
                //Console.WriteLine(win1251.GetString(win1251Bytes));
                //Console.WriteLine(text);

                //Console.ReadLine();
                
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
}
