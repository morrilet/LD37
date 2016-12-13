using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GameOverMenu : MonoBehaviour 
{
	AsyncOperation loader;

	public Text scoreText;

	void Start()
	{
		//loader = SceneManager.LoadSceneAsync ("MainGame");
		//loader.allowSceneActivation = false;

		scoreText.text = "On the bright side, you tucked away $" + PlayerPrefs.GetInt("Score").ToString("N0") + " for meth!";
	}

	public void Replay()
	{
		SceneManager.LoadScene ("MainGame");
		//loader.allowSceneActivation = true;
	}

	public void BackToMenu()
	{
		SceneManager.LoadScene ("MainMenu");
	}
}
