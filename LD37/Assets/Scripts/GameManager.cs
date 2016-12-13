using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	[SerializeField]
	protected AnimationCurve multiplierCurve;
	private static float score;
	private static float multiplier = 1.0f;
	private static int methBabyCount;

	private const int MAX_METHBABIES = 75; //The max number of methbabies before the multiplier curve flattens out.
	private const float MAX_MULTIPLIER = 25.0f; //The max multiplier value before it switches off of the curve.

	bool takenFirstShot = false;
	void InitiateFirstShot() { takenFirstShot = true; }

	void Start()
	{
		score = 0;
		multiplier = 1.0f;
		methBabyCount = 0;

		//AudioManager.PlayMusic ("MainMusicLoop");

		MethBabySpawner.OnSpawnMethBaby += AddToMethBabyCount;
		MethBabySpawner.OnSpawnMethBaby += UpdateMultiplier;

		InputManager.OnUpPressed += InitiateFirstShot;
	}

	void Update()
	{
		if (!AudioManager.musicSource.isPlaying)
			AudioManager.PlayMusic ("MainMusicLoop");
		//Debug.Log (1 * multiplier);
		if (takenFirstShot) 
		{
			score += 1 * multiplier;
		}
	}

	private void AddToMethBabyCount()
	{
		methBabyCount += 1;
	}

	private void UpdateMultiplier()
	{
		if (methBabyCount <= MAX_METHBABIES) 
		{
			multiplier = Mathf.Lerp (1.0f, MAX_MULTIPLIER, multiplierCurve.Evaluate ((float)methBabyCount / (float)MAX_METHBABIES));
		}
		else 
		{
			if (methBabyCount % (MAX_METHBABIES / 5.0f) == 0) 
			{
				multiplier += .1f;
			}
		}
	}

	public static void GameOver()
	{
		PlayerPrefs.SetInt ("Score", (int)score);
		SceneManager.LoadScene ("GameOverMenu");
	}


	public static float GetScore ()         { return score; }
	public static float GetMultiplier ()    { return multiplier; }
	public static int   GetMethBabyCount () { return methBabyCount; }
}
