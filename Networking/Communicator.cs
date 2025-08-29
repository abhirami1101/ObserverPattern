using System.Xml.Serialization;

namespace Networking
{
    public class Communicator : ICommunicator
    {
        FileSystemWatcher _watcher;

        IMessageListener _listener;

        // To store message type and listener mapping
        private readonly Dictionary<string, List<IMessageListener>> _listenersByType;

        public Communicator()
        {
            _watcher = new FileSystemWatcher();
            _watcher.Path = "C:\\temp";
            _watcher.Filter = "in.txt";
            _watcher.NotifyFilter = NotifyFilters.LastWrite;
            _watcher.EnableRaisingEvents = true;
            _watcher.Changed += OnChanged;
            _listenersByType = new Dictionary<string, List<IMessageListener>>();
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            string message = File.ReadAllText(e.FullPath);

            string messageType;
            if (message.StartsWith("chat : "))
            {
                messageType = "chat";
                message = message.Substring("chat : ".Length);
            }
            else if (message.StartsWith("screen : "))
            {
                messageType = "screen";
                message = message.Substring("screen : ".Length);
            }
            else
            {
                messageType = "others";
            }

            if (_listenersByType.ContainsKey(messageType))
            {
                foreach (var listener in _listenersByType[messageType])
                {
                    listener.OnMessageRecieved(message);
                }
            }


        }
        public void SendMessage(string message, string ip)
        {
            File.WriteAllText("C:\\temp\\out.txt", message);

        }

        public void Subscribe(IMessageListener listener)
        {
            // the listener would be added,
            // to the corresponding message type
            // in the dictionary
            if (!_listenersByType.ContainsKey(listener.MessageType))
            {
                _listenersByType[listener.MessageType] = new List<IMessageListener>();
            }

            _listenersByType[listener.MessageType].Add(listener);
        }
    }
}
