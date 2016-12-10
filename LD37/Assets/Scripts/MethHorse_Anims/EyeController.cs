using UnityEngine;
using System.Collections;

public class EyeController : MonoBehaviour 
{
	[SerializeField]
	protected float rotationSpeed;

	void Update()
	{
		Rotate ();
	}

	void Rotate()
	{
		Vector3 newRot = transform.rotation.eulerAngles;
		newRot.z += rotationSpeed;
		transform.rotation = Quaternion.Euler (newRot);
	}
}
