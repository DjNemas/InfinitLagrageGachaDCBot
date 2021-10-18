using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;

namespace InfinitLagrageGachaDCBot
{
    class Program
    {
        private DiscordSocketClient _client;
        private CommandService _command;
        private string version = "1.0";

        public static void Main(string[] args)
        => new Program().MainAsync().GetAwaiter().GetResult();

        public async Task MainAsync()
        {
            Init();
            Console.WriteLine("Version: " + version);
            _client = new DiscordSocketClient(new DiscordSocketConfig()
            {
                LogLevel = LogSeverity.Info,
            });
            _command = new CommandService(new CommandServiceConfig() {
                LogLevel = LogSeverity.Info,
            });

            new LoggingService(_client, _command);
            await new CommandHandler(_client, _command).InstallCommandsAsync();
            new DiscordEvents.DCEvents(_client);

            string token = Token.GetToken();
            if(token == "0")
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Missing Token in token.txt!");
                Console.ResetColor();
                Console.WriteLine("Press any Key to close this Application...");
                Console.ReadKey();
                Environment.Exit(0);
            }
            else
            {
                await _client.LoginAsync(TokenType.Bot, token);
            }
            await _client.StartAsync();

            // Block this task until the program is closed.
            await Task.Delay(-1);
        }

        private static void Init()
        {
            Token.CreateTokenFile();
            Files.Log.LogInit();
        }
    }
}
