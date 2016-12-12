using UnityEngine;
using System.Collections;

public class BubbleColorChanger : MonoBehaviour
{
	SpriteRenderer spriteRenderer;
	Color color1;
	[SerializeField]
	protected Color color2;
	private const float TIMER_MAX = 5f;
	private float timer;
	private bool countingUp;
	void Start ()
	{
		spriteRenderer = GetComponent<SpriteRenderer> ();
		color1 = spriteRenderer.color;
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
		spriteRenderer.color = newColor;
	}
}
