using UnityEngine;
using System.Collections;

public class MethBabySpawner : MonoBehaviour
{
	public delegate void SpawnAction();
	public static SpawnAction OnSpawnMethBaby;

	[SerializeField]
	protected GameObject methBaby;
	[SerializeField]
	protected float projectileSpeed;

	void Start()
	{
		InputManager.OnUpPressed += InstantiateMethBaby;
	}

	void InstantiateMethBaby()
	{
		GameObject child = Instantiate (methBaby, transform.position, transform.rotation) as GameObject;
		child.GetComponent<ProjectileController> ().SetSpeed (projectileSpeed);

		if (OnSpawnMethBaby != null) 
		{
			OnSpawnMethBaby ();
		}
	}
}
