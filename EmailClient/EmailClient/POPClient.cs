using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenPop.Pop3;
using Message = OpenPop.Mime.Message;
using System.Diagnostics;

namespace EmailClient
{
    class POPClient
    {
        public static List<Message> GetAllMails(string hostname, int port, bool useSsl, string username, string password)
        {
            using(Pop3Client client = new Pop3Client())
            {
                client.Connect(hostname, port, useSsl);

                client.Authenticate(username, password);

                int messageCount = client.GetMessageCount();

                Debug.WriteLine(messageCount);

                List<Message> allMessages = new List<Message>(messageCount);

                for (int i = messageCount; i > 0; i--)
                {
                    allMessages.Add(client.GetMessage(i));
                    Debug.WriteLine(client.GetMessage(i).MessagePart);
                }
                return allMessages;
            }            
        
        }
    }
}
