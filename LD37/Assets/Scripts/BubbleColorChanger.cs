using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BubbleColorChanger : MonoBehaviour
{
	Image bubbleImage;
	[SerializeField]
	protected Color color1;
	[SerializeField]
	protected Color color2;
	private const float TIMER_MAX = 5f;
	private float timer;
	private bool countingUp;

	void Start ()
	{
		bubbleImage = GetComponent<Image> ();
		countingUp = true;
	}

	void Update ()
	{
		ChangeColor ();
	}

	void ChangeColor ()
	{
		if (timer >= TIMER_MAX)
			countingUp = false;
		else if (timer <= 0)
			countingUp = true;
		
		if (countingUp)
			timer += Time.deltaTime;
		else
			timer -= Time.deltaTime;
		
		float percent = timer / TIMER_MAX;
		Color newColor = Color.Lerp (color1, color2, percent);
		bubbleImage.color = newColor;
	}
}
