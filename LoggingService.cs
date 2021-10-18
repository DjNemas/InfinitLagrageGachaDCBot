using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using InfinitLagrageGachaDCBot.Files;

public class LoggingService
{
	public LoggingService(DiscordSocketClient client, CommandService command)
	{
		client.Log += LogAsync;
		command.Log += LogAsync;
	}
	private Task LogAsync(LogMessage message)
	{
		if (message.Exception is CommandException cmdException)
		{
			string msg = $"[Command/{message.Severity}] {cmdException.Command.Aliases.First()}"
				+ $" failed to execute in {cmdException.Context.Channel}.";
			Console.WriteLine(msg);
            Log.DiscordAPIConsoleLog(msg);
			Console.WriteLine(cmdException);
			Log.DiscordAPIConsoleLog(cmdException.ToString());
		}
		else
        {
			Console.WriteLine($"[General/{message.Severity}] {message}");
			Log.DiscordAPIConsoleLog($"[General/{message.Severity}] {message}");
		}
		return Task.CompletedTask;
	}
}
