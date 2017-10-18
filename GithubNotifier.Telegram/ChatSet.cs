using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
using Telegram.Bot.Types;

namespace GithubNotifier.Telegram
{
    public class ChatSet
    {
        private class SerializedChatId
        {
            public long Id { get; set; }

            public SerializedChatId()
            {
                
            }

            public SerializedChatId(long id)
            {
                Id = id;
            }
        }

        private class ChatIdEqualityComparer : IEqualityComparer<ChatId>
        {
            public bool Equals(ChatId x, ChatId y)
            {
                if (x == null || y == null) return false;
                return x.Identifier == y.Identifier;
            }

            public int GetHashCode(ChatId obj)
            {
                return obj.Identifier.GetHashCode();
            }
        }

        public ISet<ChatId> Chats { get; }

        private readonly LiteCollection<SerializedChatId> _chats;

        public ChatSet(LiteDatabase db)
        {
            _chats = db.GetCollection<SerializedChatId>();
            Chats = new HashSet<ChatId>(_chats.FindAll().Select(c=>new ChatId(c.Id)), new ChatIdEqualityComparer());
        }

        public void ProcessUpdate(Update update)
        {
            ChatId chatId = update.Message.Chat.Id;
            if (Chats.Add(chatId))
            {
                _chats.Insert(new SerializedChatId(chatId.Identifier));
            }
        }

    }
}
