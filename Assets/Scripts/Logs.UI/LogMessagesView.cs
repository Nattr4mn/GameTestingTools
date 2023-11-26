using System.Collections.Generic;
using GameTesting.Logs.Messages;
using GameTesting.UI;
using UnityEngine;

namespace GameTesting.Logs.UI
{
	public class LogMessagesView : OpenableObject
	{
		[SerializeField] private LogMessageListener _logMessageListener;
		[SerializeField] private LogMessageView _messagePrefab;
		[SerializeField] private Transform _container;

		private List<LogMessageView> _messagePool;

		private void Awake()
		{
			_messagePool = new List<LogMessageView>();
			_logMessageListener.Updated += OnUpdate;
		}

		private void OnEnable()
		{
			OnUpdate(_logMessageListener.Messages);
			_logMessageListener.Updated += OnUpdate;
		}

		private void OnDisable()
		{
			_logMessageListener.Updated -= OnUpdate;
		}

		private void OnDestroy()
		{
			_messagePool.ForEach(message => Destroy(message.gameObject));
		}

		private void OnUpdate(IReadOnlyList<LogMessage> messages)
		{
			var from = 0;
			var to = _messagePool.Count;
			
			if (messages.Count > _messagePool.Count)
			{
				from = _messagePool.Count;
				to = _messagePool.Count + (messages.Count - _messagePool.Count);
				CreateMessageViews(messages.Count - _messagePool.Count);
			}
			
			for (int i = from; i < to; i++)
			{
				_messagePool[i].Init(messages[i]);
			}
		}

		private void CreateMessageViews(int count)
		{
			for (int i = 0; i < count; i++)
			{
				CreateMessageView();
			}
		}

		private void CreateMessageView()
		{
			var messageView = Instantiate(_messagePrefab, _container);
			_messagePool.Add(messageView);
		}
	}
}
