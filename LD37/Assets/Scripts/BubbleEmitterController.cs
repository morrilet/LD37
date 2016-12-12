using UnityEngine;
using System.Collections;

public class BubbleEmitterController : MonoBehaviour{

	ParticleSystem particleSystem;

	void Start ()
	{
		particleSystem = GetComponent<ParticleSystem> ();
		if (transform.parent.tag == "Player")
		{
			InputManager.OnUpPressed += EmitParticles;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void EmitParticles()
	{
		particleSystem.Emit (Random.Range (2, 5));
	}
}
