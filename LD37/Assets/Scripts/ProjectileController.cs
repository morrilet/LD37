using UnityEngine;
using System.Collections;

public class ProjectileController : MonoBehaviour
{
	private Vector2 velocity;
	private float speed;
	private float rotation;

	void Start()
	{
		velocity = speed * Time.deltaTime * (Vector2)transform.up;
	}

	void Update ()
	{
		Move ();
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
}
