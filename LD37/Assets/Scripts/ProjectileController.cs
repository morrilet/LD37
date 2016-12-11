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

	void MoveForward ()
	{
		velocity = speed * transform.up;
		Vector3 currentPos = transform.position;
		currentPos += (Vector3)velocity;
		transform.position = currentPos;
	}

	void SetSpeed(float _speed)
	{
		speed = _speed;
	}
}
