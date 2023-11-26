using UnityEngine;

namespace GameTesting.UI
{
	public class OpenableObject : MonoBehaviour
	{
		public void OpenOrClose()
		{
			if(!gameObject.activeInHierarchy)
			{
				Open();
			}
			else
			{
				Close();
			}
		}
		
		public void Open()
		{
			gameObject.SetActive(true);
		}
		
		public void Close()
		{
			gameObject.SetActive(false);
		}
	}
}
