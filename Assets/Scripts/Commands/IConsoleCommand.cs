namespace GameTesting.Commands
{
    public interface IConsoleCommand
    {
        public string Instruction { get; }

        public void Execute(string command);
    }
}
