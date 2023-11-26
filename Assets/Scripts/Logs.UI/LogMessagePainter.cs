using TMPro;
using UnityEngine;

namespace GameTesting.Logs.UI
{
	public class LogMessagePainter : MonoBehaviour
	{
		[SerializeField] private Color _errorColor = Color.red;
		[SerializeField] private Color _warningColor = Color.yellow;
		[SerializeField] private Color _logColor = Color.white;

		public void Paint(TMP_Text text, LogType type)
		{
			switch (type)
			{
				case LogType.Error:
				case LogType.Exception:
					text.color = _errorColor;
					return;
				case LogType.Warning:
				case LogType.Assert:
					text.color = _warningColor;
					return;
				default:
					text.color = _logColor;
					return;
			}
		}
	}
}
