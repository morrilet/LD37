using UnityEngine;
using System.Collections;

public class MethBabySpawner : MonoBehaviour
{
	[SerializeField]
	protected GameObject methBaby;
	const float SPEED = 2;

	void Start()
	{
		InputManager.OnUpPressed += InstantiateMethBaby;
	}

	void InstantiateMethBaby()
	{
		GameObject child = Instantiate (methBaby, transform.position, transform.rotation) as GameObject;
		child.GetComponent<ProjectileController> ().SetSpeed (SPEED);
	}
}
