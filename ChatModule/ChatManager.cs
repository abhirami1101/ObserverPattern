using Networking;

namespace ChatModule
{
    public class ChatManager : IMessageListener
    {
        public string MessageType => "chat";


        public void OnMessageRecieved(string message) 
        {
            Console.WriteLine($"Chat : {message}\n");
        }
    }
}
