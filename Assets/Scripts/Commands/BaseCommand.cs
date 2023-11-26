using UnityEngine;

namespace GameTesting.Commands
{
    public abstract class BaseCommand : ScriptableObject, IConsoleCommand
    {
        [SerializeField] private string _instruction;

        public string Instruction => _instruction;

        public abstract void Execute(string command);
    }
}
