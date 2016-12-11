using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	private static long score;

	void Update()
	{
		score += 5;
	}

	public static long GetScore () { return score; }
}
