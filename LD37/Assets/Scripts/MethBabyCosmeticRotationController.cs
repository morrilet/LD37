using UnityEngine;
using System.Collections;

public class MethBabyCosmeticRotationController : MonoBehaviour {

	private const float ROTATION_SPEED_RANGE = 3;
	private float rotationSpeed;

	void Start ()
	{
		SetRotationSpeed ();
	}

	void Update ()
	{
		Rotate ();
	}

	void Rotate()
	{
		Vector3 newRot = transform.rotation.eulerAngles;
		newRot.z += rotationSpeed;
		transform.rotation = Quaternion.Euler (newRot);
	}

	void SetRotationSpeed ()
	{
		rotationSpeed = 0;
		while (rotationSpeed == 0)
		{
			rotationSpeed = Random.Range (-ROTATION_SPEED_RANGE, ROTATION_SPEED_RANGE);
		}
	}
}
