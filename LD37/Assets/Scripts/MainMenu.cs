using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
	AsyncOperation loader;

	void Start()
	{
		loader = SceneManager.LoadSceneAsync ("MainGame");
		loader.allowSceneActivation = false;
	}

	public void PlayGame()
	{
		loader.allowSceneActivation = true;
	}

	public void ViewStory()
	{
		SceneManager.LoadScene ("StoryMenu");
	}

	public void Exit()
	{
		Application.Quit ();
	}
}
