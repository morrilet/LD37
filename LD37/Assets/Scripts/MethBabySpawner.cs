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
		child.GetComponent<ProjectileController> ().parent = this.gameObject;
		AudioManager.PlayEffect ("Pucker");

		Physics2D.IgnoreCollision (child.GetComponent<Collider2D> (), GetComponent<Collider2D> (), true);

		if (OnSpawnMethBaby != null) 
		{
			OnSpawnMethBaby ();
		}
	}

	void OnDestroy()
	{
		OnSpawnMethBaby = null;
	}
}
