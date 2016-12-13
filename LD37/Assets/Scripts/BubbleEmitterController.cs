using UnityEngine;
using System.Collections;

public class BubbleEmitterController : MonoBehaviour{

	ParticleSystem particleSystem;
	private bool isAmbient;
	private float timer;
	private float timerMax;

	void Start ()
	{
		particleSystem = GetComponent<ParticleSystem> ();
		if (transform.parent.tag == "Player")
		{
			InputManager.OnUpPressed += EmitParticles;
			isAmbient = false;
		} else
		{
			isAmbient = true;
			timer = 0f;
//			timerMax = Random.Range (10, 20);
			timer = 2;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (isAmbient)
			CheckForAmbientEmission ();
	}

	void CheckForAmbientEmission ()
	{
		if (timer >= timerMax)
		{
			EmitParticles ();
			timer = 0f;
			timerMax = Random.Range (10, 20);
		}
		else
		{
			timer += Time.deltaTime;
		}
	}

	void EmitParticles()
	{
		particleSystem.Emit (Random.Range (2, 5));
	}
}
