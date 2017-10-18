using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace GithubNotifier.Telegram
{
    internal static class TelegramBotClientExtensions
    {
        public static Task<IList<Update>> ReadAllMessages(this TelegramBotClient client)
            => client.ReadAllMessages(CancellationToken.None);

        public static async Task<IList<Update>> ReadAllMessages(this TelegramBotClient client, CancellationToken token)
        {
            var result = new List<Update>();
            int offset = 0;
            const int count = 100;
            Update[] updates;

            do
            {
                updates = await client.GetUpdatesAsync(offset, count, 0, null, token);
                offset = updates.Select(u => u.Id).Max();
                result.AddRange(updates);

            } while (updates.Length == count);

            return result;

        }
    }
}
