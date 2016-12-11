using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreText : MonoBehaviour 
{
	private Text scoreText;
	private float startingFontSize;
	[SerializeField]
	protected float maxFontSize;
	[SerializeField]
	protected AnimationCurve explosionCurve;

	private const float EXPLOSION_DURATION = 1.0f;

	void Start()
	{
		scoreText = GetComponent<Text> ();
		startingFontSize = scoreText.fontSize;

		InputManager.OnRightPressed += ApplyJuice;
	}

	void Update()
	{
		if (float.Parse(scoreText.text.ToString()) % 1000f == 0.0f) 
		{
			ApplyJuice ();
		}
	}

	void ApplyJuice()
	{
		StopCoroutine ("JuiceCoroutine");
		StartCoroutine (JuiceCoroutine ());
	}

	//Makes the text expand and emits bursts of particles.
	private IEnumerator JuiceCoroutine()
	{
		float timer = 0.0f;
		while (timer < EXPLOSION_DURATION)
		{
			float percentComplete = timer / EXPLOSION_DURATION;
			scoreText.fontSize = (int)Mathf.Lerp (scoreText.fontSize, maxFontSize, explosionCurve.Evaluate (percentComplete));
			Debug.Log (explosionCurve.Evaluate (percentComplete) + " :: " + percentComplete + "%");

			timer += Time.deltaTime;
			yield return null;
		}
		scoreText.fontSize = (int)startingFontSize;
	}
}
