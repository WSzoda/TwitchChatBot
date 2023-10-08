using ShiraSodaBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ShiraSodaBot.Data
{
    public class TwitchChatHandler
    {
        public StreamReader reader;
        public StreamWriter writer;
        public TwitchChatHandler(string token, string channelName, string ownerName)
        {
            TcpClient client = new TcpClient("irc.chat.twitch.tv", 6667);

            reader = new StreamReader(client.GetStream());
            writer = new StreamWriter(client.GetStream());

            writer.WriteLine("PASS oauth:" + token);
            writer.WriteLine("NICK " + ownerName);
            writer.WriteLine("JOIN #" + channelName);
            writer.Flush();
        }

        public ChatMessage ReadMessage()
        {
            string message;
            while(true)
            {
                message = ReadTCP();
                if(message == null)
                {
                    Thread.Sleep(100);
                    continue;
                }
                if(message.Contains("PING"))
                {
                    PingTwitch();
                    continue;
                }
                if (!message.Contains("PRIVMSG"))
                {
                    Thread.Sleep(100);
                    continue;
                }
                break;
            }

            return FormatMessage(message);
        }

        public string ReadTCP()
        {
            try
            {
                return reader.ReadLine();
            }
            catch
            {
                return null;
            }
        }

        public ChatMessage FormatMessage(string message)
        {
            int startingIndex = message.IndexOf(":") + 1;
            int endingIndex = message.IndexOf("!");
            int length = endingIndex - startingIndex;
            string senderName = message.Substring(startingIndex, length);

            startingIndex = message.IndexOf(":", 1) + 1;
            string chatMessage = message.Substring(startingIndex);

            return new ChatMessage { senderName = senderName, chatMessage = chatMessage };
        }

        public void PingTwitch()
        {
            writer.WriteLine("PONG :tmi.twitch.tv");
            writer.Flush();
        }
    }
}
