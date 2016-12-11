using UnityEngine;
using System.Collections;

public class ProjectileController : MonoBehaviour
{
	private Vector2 velocity;
	private float speed;
	private float rotation;

	void Update ()
	{
		MoveForward ();
	}

	#region Collision
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Wall"))
		{
			for (int i = 0; i < other.contacts.Length; i++)
			{
				velocity = Vector2.Reflect (velocity, other.contacts [i].normal);
			}
		}
	}
	#endregion

	#region Movement
	void MoveForward ()
	{
		velocity = speed * Time.deltaTime * transform.up;
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
