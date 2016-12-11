using UnityEngine;
using System.Collections;

public class MethBabySpawner : MonoBehaviour
{
	[SerializeField]
	protected GameObject methBaby;

	void Start()
	{
		InputManager.OnUpPressed += InstantiateMethBaby;
	}

	void InstantiateMethBaby()
	{
		Instantiate (methBaby, transform.position, transform.rotation);
	}
}
