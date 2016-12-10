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

	void Accelerate(float duration, float accAmount)
	{
	}

	void ApplyDampening(out Vector2 vel)
	{
		vel = Vector2.zero;
	}

	void Turn(float degrees)
	{
	}
}