using Networking;

namespace ScreenShareModule
{
    public class ScreenShareManager : IMessageListener
    {
        public string MessageType => "screen";

        public void OnMessageRecieved(string message)
        {
            Console.WriteLine($"Screen Sharing : {message}\n");
        }
    }
}
