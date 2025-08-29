using Networking;

namespace ScreenShareModule
{
    public class ScreenShareManager : IMessageListener
    {
        // Screen share manager listens for  the messages that is of screen type.
        public string MessageType => "screen";

        public void OnMessageRecieved(string message)
        {
            // Message receival logic
            Console.WriteLine($"Screen Sharing : {message}\n");
        }
    }
}
