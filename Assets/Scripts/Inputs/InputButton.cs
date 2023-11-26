using System;
using UnityEngine;

namespace GameTesting.Inputs
{
	public class InputButton : MonoBehaviour
	{
		[SerializeField] private KeyCode _keyCode;
		
		public event Action Performed;
		public event Action Released;

		private void Awake()
		{
			DontDestroyOnLoad(gameObject);
		}

		private void Update()
		{
			if (Input.GetKeyDown(_keyCode))
			{
				Performed?.Invoke();
			}
			
			if (Input.GetKeyUp(_keyCode))
			{
				Released?.Invoke();
			}
		}
	}
}
