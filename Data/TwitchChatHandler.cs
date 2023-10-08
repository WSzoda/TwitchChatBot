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
        private StreamReader _reader;
        private StreamWriter _writer;
        private string _channelName;

        public TwitchChatHandler(string token, string channelName, string ownerName)
        {
            _channelName = channelName;

            TcpClient client = new TcpClient("irc.chat.twitch.tv", 6667);

            _reader = new StreamReader(client.GetStream());
            _writer = new StreamWriter(client.GetStream());

            _writer.WriteLine("PASS oauth:" + token);
            _writer.WriteLine("NICK " + ownerName);
            _writer.WriteLine("JOIN #" + channelName);
            _writer.Flush();
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
                return _reader.ReadLine();
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
            _writer.WriteLine("PONG :tmi.twitch.tv");
            _writer.Flush();
        }

        public void SendMessage(string message)
        {
            _writer.WriteLine("PRIVMSG #" + _channelName + " :" + message);
            _writer.Flush();
        }
    }
}
