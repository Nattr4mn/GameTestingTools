using UnityEngine;

namespace GameTesting.Logs.Messages
{
	public class LogMessage
	{
		public LogMessage(string time, string message, string stackTrace, LogType type)
		{
			Time = time;
			Message = message;
			StackTrace = stackTrace;
			Type = type;
		}
		
		public string Time { get; private set; }
		public string Message { get; private set; }
		public string StackTrace { get; private set; }
		public LogType Type { get; private set; }

		public override string ToString()
		{
			return $"{Time}:{Message}\n{StackTrace}";
		}
	}
}
