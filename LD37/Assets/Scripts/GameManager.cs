using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	[SerializeField]
	protected AnimationCurve multiplierCurve;
	private static float score;
	private static float multiplier;
	private static int methBabyCount;

	private const int MAX_METHBABIES = 50; //The max number of methbabies before the multiplier curve flattens out.
	private const float MAX_MULTIPLIER = 5.0f;

	void Start()
	{
		multiplier = 1.0f;
		
		MethBabySpawner.OnSpawnMethBaby += AddToMethBabyCount;
		MethBabySpawner.OnSpawnMethBaby += UpdateMultiplier;
	}

	void Update()
	{
		Debug.Log (1 * multiplier);
		score += 1 * multiplier;
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
			if (methBabyCount % (MAX_METHBABIES / 2.0f) == 0) 
			{
				multiplier += .1f;
			}
		}
	}


	public static float GetScore ()         { return score; }
	public static float GetMultiplier ()    { return multiplier; }
	public static int   GetMethBabyCount () { return methBabyCount; }
}
