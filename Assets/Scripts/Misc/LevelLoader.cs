using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameTesting.Misc
{
	public class LevelLoader : MonoBehaviour
	{
		[SerializeField] private string _levelName = "LogScene";
		
		private void Awake()
		{
			var scene = SceneManager.GetSceneByName(_levelName);
			
			if (!scene.isLoaded)
			{
				SceneManager.LoadScene(_levelName, LoadSceneMode.Additive);
			}
		}
	}
}
