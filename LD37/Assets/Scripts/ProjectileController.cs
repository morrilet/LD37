using UnityEngine;
using System.Collections;

public class ProjectileController : MonoBehaviour
{
	private Vector2 velocity;
	private float speed;
	private float rotation;
	private float collisionTimer;
	private const float COLLISION_TIMER_MAX = 1.5f;

	[HideInInspector]
	public GameObject parent;

	void Start()
	{
		velocity = speed * Time.deltaTime * (Vector2)transform.up;
		collisionTimer = 0;
	}

	void Update ()
	{
		Move ();
		CheckIfCanCollide ();
	}

	#region Collision
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Wall"))
		{
			velocity = Vector2.Reflect (velocity, other.contacts [0].normal);
			for (int i = 0; i < other.contacts.Length; i++)
			{
				//Debug.DrawRay (other.contacts [i].point, other.contacts [i].normal, Color.blue);
				//Debug.DrawRay (other.contacts [i].point, (Vector3)Vector2.Reflect (velocity, other.contacts [i].normal).normalized, Color.red);
				//velocity = Vector2.Reflect (velocity, other.contacts [i].normal);
			}
		}
	}

	void OnCollisionStay2D(Collision2D other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Wall"))
		{
			velocity = Vector2.Reflect (velocity, other.contacts [0].normal);
			for (int i = 0; i < other.contacts.Length; i++)
			{
				//Debug.DrawRay (other.contacts [i].point, other.contacts [i].normal, Color.blue);
				//Debug.DrawRay (other.contacts [i].point, (Vector3)Vector2.Reflect (velocity, other.contacts [i].normal).normalized, Color.red);
				//velocity = Vector2.Reflect (velocity, other.contacts [i].normal);
			}
		}
	}
	#endregion

	#region Movement
	void Move ()
	{
		Vector3 currentPos = transform.position;
		currentPos += (Vector3)velocity;
		transform.position = currentPos;
	}
	#endregion

	public void SetSpeed(float _speed)
	{
		speed = _speed;
	}

	void CheckIfCanCollide ()
	{
		if (collisionTimer >= COLLISION_TIMER_MAX)
		{
			Physics2D.IgnoreCollision (parent.GetComponent<Collider2D> (), GetComponent<Collider2D> (), false);
		}
		else
		{
			collisionTimer += Time.deltaTime;
		}
	}
}
