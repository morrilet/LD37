using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour 
{
	public delegate void KeyAction();
	public static event KeyAction OnUpPressed;
	public static event KeyAction OnLeftPressed;
	public static event KeyAction OnRightPressed;

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

		if (Input.GetKeyDown (KeyCode.D) || Input.GetKeyDown (KeyCode.RightArrow)) 
		{
			if (OnRightPressed != null) 
			{
				OnRightPressed ();
			}
		}
	}
}
