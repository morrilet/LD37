using UnityEngine;
using System.Collections;

/// <summary>
/// This handles player movement. This includes acceleration, velocity dampening,
/// and turning.
/// </summary>
public class PlayerController : MonoBehaviour 
{
	private Vector2 velocity;
	[SerializeField]
	protected float turnSpeed;
	[SerializeField]
	protected float accSpeed;
	[SerializeField]
	protected float dampening;

	private const float ACC_DURATION = 0.1f;

	//Whether or not to apply dampening to the velocity. Set to false during acceleration.
	private bool applyDampening = true;

	void Start()
	{
		InputManager.OnUpPressed += Accelerate;
	}

	void Update()
	{
		Move ();
	}

	void Move()
	{
		Vector3 newPos = transform.position;
		if (applyDampening) 
		{
			ApplyDampening ();
		}
		newPos += (Vector3)velocity;
		transform.position = newPos;
	}

	void Accelerate()
	{
		StartCoroutine (AccelerateCoroutine (ACC_DURATION, accSpeed));
	}

	private IEnumerator AccelerateCoroutine(float duration, float accAmount)
	{
		float timer = 0.0f;
		while (timer < duration) 
		{
			if (applyDampening)
				applyDampening = false;

			float accStep = Mathf.Lerp (0.0f, accAmount, (timer / duration));
			velocity += (accStep * -(Vector2)transform.up);
			timer += Time.deltaTime;
			//Debug.Log ("AccStep = " + accStep + " :: AccStepNormalized = " + accStep * (Vector2)transform.up);
			yield return null;
		}
		applyDampening = true;
	}

	void ApplyDampening()
	{
		velocity *= dampening;
	}

	void Turn(float degrees)
	{
	}

	public Vector2 GetVelocity () { return velocity; }
}