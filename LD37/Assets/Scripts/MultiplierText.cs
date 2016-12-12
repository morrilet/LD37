using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MultiplierText : MonoBehaviour 
{

	private Text multiplierText;
	private float startingFontSize;
	[SerializeField]
	protected float maxFontSize;
	[SerializeField]
	protected AnimationCurve explosionCurve;

	private float currentMultiplier;
	private float prevMultiplier;

	private const float EXPLOSION_DURATION = 1.0f;

	void Start ()
	{
		multiplierText = GetComponent<Text> ();
		startingFontSize = multiplierText.fontSize;
		InputManager.OnDownPressed += ApplyJuice;

		currentMultiplier = GameManager.GetMultiplier ();
		prevMultiplier = currentMultiplier;
	}

	void Update ()
	{
		multiplierText.text = "x" + GameManager.GetMultiplier ().ToString ("N1");

		currentMultiplier = GameManager.GetMultiplier ();
		if((int)(currentMultiplier * 10f) / 10f != (int)(prevMultiplier * 10f) / 10f)
		{
			ApplyJuice ();
		}
		prevMultiplier = currentMultiplier;
	}

	void ApplyJuice()
	{
		//StopCoroutine ("JuiceCoroutine");
		StartCoroutine (JuiceCoroutine ());
	}

	//Makes the text expand
	private IEnumerator JuiceCoroutine()
	{
		float timer = 0.0f;
		while (timer < EXPLOSION_DURATION)
		{
			float percentComplete = timer / EXPLOSION_DURATION;
			multiplierText.fontSize = (int)Mathf.Lerp (startingFontSize, maxFontSize, explosionCurve.Evaluate (percentComplete));

			timer += Time.deltaTime;
			yield return null;
		}
		multiplierText.fontSize = (int)startingFontSize;
	}
}
