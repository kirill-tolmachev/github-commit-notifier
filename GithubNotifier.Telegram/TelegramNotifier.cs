using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GithubNotifier.Core;
using GithubNotifier.Core.Formatters;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace GithubNotifier.Telegram
{
    public class TelegramNotifier : INotifier
    {
        private readonly TelegramBotClient _client;
        private readonly IFormatter _formatter;
        private readonly ChatSet _chatCollection;

        public TelegramNotifier(TelegramBotClient client, IFormatter formatter, ChatSet chatCollection)
        {
            _client = client;
            _formatter = formatter;
            _chatCollection = chatCollection;
        }

        public async Task Notify(GithubPayload payload)
        {
            await PopulateChatCollection();
            string message = _formatter.Format(payload);
            foreach (var chat in _chatCollection.Chats)
            {
                await _client.SendTextMessageAsync(chat, message);
            }
        }

        private async Task PopulateChatCollection()
        {
            var updates = await _client.ReadAllMessages();
            foreach (var update in updates)
            {
                _chatCollection.ProcessUpdate(update);
            }
        }

        
        
    }
}
