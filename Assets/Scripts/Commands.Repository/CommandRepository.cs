using System.Collections.Generic;
using UnityEngine;

namespace GameTesting.Commands.Repository
{
	[CreateAssetMenu(
		menuName = nameof(GameTesting) + "/" + nameof(Commands) + "/"  + nameof(CommandRepository), 
		fileName = nameof(CommandRepository))
	]
	public class CommandRepository : ScriptableObject
	{
		[SerializeField] private List<BaseCommand> _commands;

		private void OnEnable()
		{
			Commands = new Dictionary<string, IConsoleCommand>();
			AddCommands(_commands);
		}

		public Dictionary<string, IConsoleCommand> Commands { get; private set; }

		public void AddCommands(IReadOnlyList<IConsoleCommand> commands)
		{
			foreach(var command in commands)
			{
				AddCommand(command);
			}
		}

		public void AddCommand(IConsoleCommand command)
		{
			Commands[command.Instruction] = command;
		}

		public bool TryGetCommand(string commandName, out IConsoleCommand command)
		{
			return Commands.TryGetValue(commandName, out command);
		}
	}
}
