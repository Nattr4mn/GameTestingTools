using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameTesting.Logs.Messages
{
	public class LogMessageListener : MonoBehaviour
	{
		private List<LogMessage> _messages;

		public event Action<IReadOnlyList<LogMessage>> Updated;
		
		private void Awake()
		{
			_messages = new List<LogMessage>();
			Application.logMessageReceived += Write;
		}

		public IReadOnlyList<LogMessage> Messages => _messages;

		public void Write(string logString, string stackTrace, LogType type)
		{
			_messages.Add(new LogMessage(DateTime.Now.ToLongTimeString(), logString, stackTrace, type));
			Updated?.Invoke(_messages);
		}
	}

}