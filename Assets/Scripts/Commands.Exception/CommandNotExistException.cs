using System;

namespace GameTesting.Commands.Exception
{
	public class CommandNotExistException : System.Exception
	{
		private static string message = "The command {command} does not exist!";
		private static string commandKey = "{command}";

		public CommandNotExistException(string commandName) : base(message.Replace(commandKey, commandName)) {}
	}
}
