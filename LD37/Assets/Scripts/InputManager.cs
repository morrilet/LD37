using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour 
{
	public delegate void KeyAction();
	public static event KeyAction OnUpPressed;
	public static event KeyAction OnLeftPressed;
	public static event KeyAction OnRightPressed;
	public static event KeyAction OnLeftHeld;
	public static event KeyAction OnRightHeld;

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.UpArrow)) 
		{
			if (OnUpPressed != null) 
			{
				OnUpPressed ();
			}
		}

		if (Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown (KeyCode.LeftArrow)) 
		{
			if (OnLeftPressed != null) 
			{
				OnLeftPressed ();
			}
		}

		if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) 
		{
			if (OnLeftHeld != null) 
			{
				OnLeftHeld ();
			}
		}

		if (Input.GetKeyDown (KeyCode.D) || Input.GetKeyDown (KeyCode.RightArrow)) 
		{
			if (OnRightPressed != null) 
			{
				OnRightPressed ();
			}
		}

		if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) 
		{
			if (OnRightHeld != null) 
			{
				OnRightHeld ();
			}
		}
	}
}
