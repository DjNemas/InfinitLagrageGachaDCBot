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
	private readonly DiscordSocketClient _client;
	private readonly CommandService _command;
	public LoggingService(DiscordSocketClient client, CommandService command)
	{
		_client = client;
		_command = command;

		_client.Log += LogAsync;
		_command.Log += LogAsync;
		_command.CommandExecuted += CommandExecuted;
	}

    private async Task CommandExecuted(Optional<CommandInfo> arg1, ICommandContext arg2, IResult arg3)
    {
		if (arg3.Error == CommandError.BadArgCount)
        {
			await arg2.Channel.SendMessageAsync(arg3.ErrorReason);
        }
		if (arg3.Error == CommandError.MultipleMatches)
		{
			await arg2.Channel.SendMessageAsync(arg3.ErrorReason);
		}
		if (arg3.Error == CommandError.ObjectNotFound)
		{
			await arg2.Channel.SendMessageAsync(arg3.ErrorReason);
		}
		if (arg3.Error == CommandError.ParseFailed)
		{
			await arg2.Channel.SendMessageAsync(arg3.ErrorReason);
		}
		if (arg3.Error == CommandError.UnknownCommand)
		{
			await arg2.Channel.SendMessageAsync(arg3.ErrorReason);
		}
		if (arg3.Error == CommandError.UnmetPrecondition)
		{
			await arg2.Channel.SendMessageAsync(arg3.ErrorReason);
		}
		if (arg3.Error == CommandError.Unsuccessful)
		{
			await arg2.Channel.SendMessageAsync(arg3.ErrorReason);
		}
		if (arg3.Error == CommandError.Exception)
		{
			await arg2.Channel.SendMessageAsync(arg3.ErrorReason);
		}
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
