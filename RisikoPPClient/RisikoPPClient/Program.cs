using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Networking_Client;

namespace RisikoPPClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Client";

            SetupClient();
            Client.MessageReceived += MessageReceived;

            while (true)
            {
                MessageCreator cr = new MessageCreator(0);
                cr.AddString(Console.ReadLine());
                Client.Send(cr.getBytes());
            }
        }

        private static void MessageReceived(MessageReceivedEventArgs e)
        {
            string data = new MessageEncoder(e.message).GetString();

            Console.WriteLine(data);
        }

        static void SetupClient()
        {
            Client.Connect(new System.Net.IPEndPoint(IPAddress.Parse("127.0.0.1"), 44444));
            Ticker.Start(10);
            Ticker.Tick += Client.Tick;
        }
    }
}
