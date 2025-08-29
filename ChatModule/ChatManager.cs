using Networking;

namespace ChatModule
{
    public class ChatManager : IMessageListener
    {
        // Chat Manager would have the chat type of messages.
        public string MessageType => "chat";


        public void OnMessageRecieved(string message) 
        {
            // logic for chat-message received.
            Console.WriteLine($"Chat message : {message}\n");
        }
    }
}
