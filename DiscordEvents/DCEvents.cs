using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinitLagrageGachaDCBot.DiscordEvents
{
    public class DCEvents
    {
        private readonly DiscordSocketClient _client;

        public DCEvents(DiscordSocketClient client)
        {
            _client = client;
            _client.GuildAvailable += GuildAvailable;
        }

        private Task GuildAvailable(SocketGuild guild)
        {
            return Task.CompletedTask;
        }
    }
}
