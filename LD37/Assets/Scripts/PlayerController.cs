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
	private Collider2D coll;

	void Start()
	{
		coll = GetComponent<Collider2D> ();

		InputManager.OnUpPressed += Accelerate;
		InputManager.OnRightHeld += TurnRight;
		InputManager.OnLeftHeld  += TurnLeft;
		InputManager.OnDownHeld  += ApplyDampening;
	}

	void Update()
	{
		Move ();
	}

	#region Collision
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer ("Wall")) 
		{
			velocity *= .65f;
			velocity = Vector2.Reflect (velocity, other.contacts [0].normal);
		}
	}

	void OnCollisionStay2D(Collision2D other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer ("Wall")) 
		{
			velocity = Vector2.Reflect (velocity, other.contacts [0].normal);
		}
	}
	#endregion

	#region Movement
	void Move()
	{
		//Debug.DrawRay (transform.position, (Vector3)velocity * 10f);
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
		Vector3 forwardVector = transform.up;
		while (timer < duration) 
		{
			if (applyDampening)
				applyDampening = false;

			float accStep = Mathf.Lerp (0.0f, accAmount, (timer / duration));
			velocity += (accStep * -(Vector2)forwardVector);
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
	#endregion

	#region Turning
	void TurnLeft()
	{
		Turn (turnSpeed);
	}

	void TurnRight()
	{
		Turn (-turnSpeed);
	}

	private void Turn(float degrees)
	{
		Vector3 newRot = transform.rotation.eulerAngles;
		newRot.z += degrees;
		transform.rotation = Quaternion.Euler (newRot);
	}
	#endregion
		
	public Vector2 GetVelocity () { return velocity; }
}