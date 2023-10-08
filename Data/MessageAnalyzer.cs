using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShiraSodaBot.Data;

namespace ShiraSodaBot.Data
{
    public class MessageAnalyzer
    {
        private TwitchChatHandler _twitchChatHandler;

        public MessageAnalyzer(TwitchChatHandler twitchChatHandler)
        {
            _twitchChatHandler = twitchChatHandler;

        }

        public void AnalyzeMessage(string message)
        {
            if (message.Contains("!soda"))
            {
                int count = DatabaseManager.ReadCounter();
                _twitchChatHandler.SendMessage($"ShiraMelonSoda has been said {count} times!");
                Console.WriteLine(count);
            }
            else if (message.Contains("ShiraMelonSoda"))
            {
                var matchQuery = from word in message.Split(' ')
                                 where word.ToLowerInvariant() == "shiramelonsoda"
                                 select word;
                int count = matchQuery.Count();
                Console.WriteLine(count);
                DatabaseManager.IncrementCounter(count);
            }
        }   
    }
}
