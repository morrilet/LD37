using UnityEngine;
using System.Collections;

public class ProjectileController : MonoBehaviour
{
	private Vector2 velocity;
	private float rotation;

	void Start ()
	{
		velocity = new Vector2 (2, 2);
	}

	void Update ()
	{
		MoveForward ();
	}

	void MoveForward ()
	{
		Vector3 currentPos = transform.position;
		currentPos = transform.position + (Vector3)velocity;
		transform.position = currentPos;
	}
}
