using UnityEngine;
using System.Collections;

public class HeadController : MonoBehaviour 
{
	private const float SHAKE_DURATION = 0.4f;
	private const float SHAKE_INTENSITY = 0.075f;

	private Vector3 startLocalPos; //The starting local position.

	void Start()
	{
		startLocalPos = transform.localPosition;
		InputManager.OnUpPressed += Shake;
	}

	void Shake()
	{
		StopCoroutine ("ShakeCoroutine");
		StartCoroutine (ShakeCoroutine (SHAKE_DURATION, SHAKE_INTENSITY));
	}

	private IEnumerator ShakeCoroutine(float duration, float intensity)
	{
		float timer = 0.0f;

		while (timer < duration) 
		{
			Vector3 tempLocalPos = startLocalPos;

			float tempX = Random.Range (-intensity, intensity);
			float tempY = Random.Range (-intensity, intensity);
			tempLocalPos += new Vector3 (tempX, tempY, tempLocalPos.z);
			transform.localPosition = tempLocalPos;

			timer += Time.deltaTime;
			yield return null;
		}

		transform.localPosition = startLocalPos;
	}
}
