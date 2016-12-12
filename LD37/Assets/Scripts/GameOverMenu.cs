using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverMenu : MonoBehaviour 
{
	AsyncOperation loader;

	void Start()
	{
		loader = SceneManager.LoadSceneAsync ("MainGame");
		loader.allowSceneActivation = false;
	}

	public void Replay()
	{
		loader.allowSceneActivation = true;
	}

	public void BackToMenu()
	{
		SceneManager.LoadScene ("MainMenu");
	}
}
