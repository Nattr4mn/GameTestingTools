using GameTesting.UI;
using UnityEngine;

namespace GameTesting.Inputs.Listener
{
	[RequireComponent(typeof(InputButton))]
	public class UIInputListener : MonoBehaviour
	{
		[SerializeField] private OpenableObject _openableObject;
		
		private InputButton _input;

		private void Awake()
		{
			_input = GetComponent<InputButton>();
		}

		private void OnEnable()
		{
			_input.Performed += _openableObject.OpenOrClose;
		}
		
		private void OnDisable()
		{
			_input.Performed -= _openableObject.OpenOrClose;
		}
	}
}
