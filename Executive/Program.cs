using ChatModule;
using Networking;
using ScreenShareModule;
using System.Diagnostics;

namespace Executive
{
    class Listener : IMessageListener
    {
        public string MessageType => "others";
        public void OnMessageRecieved(string message)
        {
            Console.WriteLine($"Message Recieved: {message}\n");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            ICommunicator communicator = new Communicator();
            communicator.SendMessage("Hii there\n", "128.0.0");
            Console.WriteLine("message sent successfully\n");

            IMessageListener listener = new Listener();
            IMessageListener chatManager = new ChatManager();
            IMessageListener screenShareManager = new ScreenShareManager();

            // Subscribe listeners
            communicator.Subscribe(listener);
            communicator.Subscribe(chatManager);
            communicator.Subscribe(screenShareManager);


            Console.WriteLine("Communicator subscribed\n");
            Console.WriteLine("Press any key to continue\n");
            Console.ReadKey();
        }
    }
}
