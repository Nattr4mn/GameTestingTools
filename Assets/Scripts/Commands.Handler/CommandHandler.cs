using System;
using GameTesting.Commands.Exception;
using GameTesting.Commands.Repository;
using UnityEngine;

namespace GameTesting.Commands.Handler
{
    public sealed class CommandHandler : MonoBehaviour
    {
        [field: SerializeField] public CommandRepository Repository { get; private set; }

        public void Execute(string commandName)
        {
            if (string.IsNullOrEmpty(commandName))
            {
                return;
            }
            
            var splitCommand = commandName.Split(" ");
            
            if (Repository.TryGetCommand(splitCommand[0], out IConsoleCommand command))
            {
                command.Execute(commandName);
                Debug.Log($"The command \"{commandName}\" has been executed!");
            }
            else
            {
                throw new CommandNotExistException("\"" + commandName + "\"");
            }
        }
    }

}