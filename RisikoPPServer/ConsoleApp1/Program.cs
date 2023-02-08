using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Networking_Server;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Server";

            StartServer();

            Client.MessageReceived += MessageReceived;
            Client.NewClientConnected += NewClientConnected;
            Client.ClientDisconnected += ClientDisconnected;

            string input;

            while ((input = Console.ReadLine()) != "quit")
            {
                MessageCreator cr = new MessageCreator(0);
                cr.AddString(input);
                byte[] bytes = cr.getBytes();

                foreach (KeyValuePair<int, Client> item in Server.clients)
                {
                    item.Value.Send(bytes);
                }
            }

            Server.Stop();
        }

        private static void ClientDisconnected(object sender, ClientDisconnectedEventArgs e)
        {

        }

        private static void NewClientConnected(object sender, NewClientConnectedEventArgs e)
        {

        }

        private static void MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            string data = new MessageEncoder(e.message).GetString();

            Console.WriteLine(data);
        }

        static void StartServer()
        {
            Server.Start(44444);
            Ticker.Start(10);
            Ticker.Tick += Server.Tick;
        }
    }
}
