using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Networking
{
    public interface ICommunicator
    {
        void SendMessage(string message, string ip);

        void Subscribe(IMessageListener listener);
    }
}
