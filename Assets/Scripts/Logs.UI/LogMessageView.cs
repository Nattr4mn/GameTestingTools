using GameTesting.Logs.Messages;
using TMPro;
using UnityEngine;

namespace GameTesting.Logs.UI
{
	public class LogMessageView : MonoBehaviour
	{
		[SerializeField] private TMP_Text _time;
		[SerializeField] private TMP_Text _message;
		[SerializeField] private LogMessagePainter _painter;

		public void Init(LogMessage logMessage)
		{
			_time.text = logMessage.Time;
			_message.text = logMessage.Message;
			
			_painter.Paint(_time, logMessage.Type);
			_painter.Paint(_message, logMessage.Type);
		}
	}
}
