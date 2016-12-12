using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class StoryMenu : MonoBehaviour 
{
	AsyncOperation loader;

	void Start()
	{
		loader = SceneManager.LoadSceneAsync ("MainMenu");
		loader.allowSceneActivation = false;
	}

	public void Back()
	{
		loader.allowSceneActivation = true;
	}
}
