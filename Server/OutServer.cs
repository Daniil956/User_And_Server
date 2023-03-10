// using System.Net.Sockets;
// using System.Net;
// using System.Text;

// namespace Server
// {
//     class OutServer
//     {
//         TcpListener server;

//         public OutServer()
//         {
//             server = new TcpListener(IPAddress.Parse("127.0.0.1"), 5555);
//             server.Start();

//             LoopClients();
//         }

//         void LoopClients()
//         {
//             while(true)
//             {
//                 TcpClient client = server.AccepTcpClient();

//                 Thread thread = new Thread(()=> HandleClient(client));
//                 thread.Start();
//             }
//         }
        
//         void HandleClient(TcpClient client)
//         {
//             StreamReader sReader = new StreamReader(LoopClients.GetStream(), Encoding.UTF8);
//             //StreamReader sWriter = new StreamWriter(LoopClients.GetStream(), Encoding.UTF8);

//             while (true)
//             {
//                 string massege = aReader.ReadLine();
//                 System.Console.WriteLine($"client wrote -{massege}");
//             }
//         }
//     }
// }


using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Server
{
    class OurServer
    {
        TcpListener server;

        public OurServer()
        {
            server = new TcpListener(IPAddress.Parse("127.0.0.1"), 5555);
            server.Start();

            LoopClients();  
        }

        void LoopClients()
        {
            while (true)
            {
                TcpClient client = server.AcceptTcpClient();

                Thread thread = new Thread(() => HandleClient(client));
                thread.Start();
            }
        }

        void HandleClient(TcpClient client)
        {
            StreamReader sReader = new StreamReader(client.GetStream(), Encoding.UTF8);
            StreamWriter sWriter = new StreamWriter(client.GetStream(), Encoding.UTF8);

            while (true)
            {
                string message = sReader.ReadLine();
                Console.WriteLine($"???????????? ?????????????? - {message}");

                Console.WriteLine("?????????? ?????????????????? ??????????????: ");
                string answer = Console.ReadLine();
                sWriter.WriteLine(answer);
                sWriter.Flush();
            }
        }
    }
}