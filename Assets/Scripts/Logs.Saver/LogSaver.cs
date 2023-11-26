using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using GameTesting.Logs.Messages;
using UnityEngine;

namespace GameTesting.Logs.Saver
{
	public class LogSaver : MonoBehaviour
	{
		[SerializeField] private LogMessageListener _messageListener;

		private void OnDestroy()
		{
			Save(_messageListener.Messages);
		}

		private void Save(IReadOnlyList<LogMessage> messages)
		{
			var date = DateTime.Now;
			var fileName = $"Log_{date.Day}{date.Month}{date.Year}{date.Hour}{date.Minute}{date.Second}.txt";
			var log = ConversionToString(messages);

			using (var fileStream = new FileStream(fileName, FileMode.OpenOrCreate))
			{
				byte[] buffer = Encoding.Default.GetBytes(log);
				fileStream.Write(buffer);
			}
		}

		private string ConversionToString(IReadOnlyList<LogMessage> messages)
		{
			var logList = new List<string>();

			foreach (var message in messages)
			{
				logList.Add(message.ToString());
			}

			return string.Join("\n", logList);
		}
	}
}
