using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour 
{
	public delegate void KeyAction();
	public static event KeyAction OnUpPressed;
	public static event KeyAction OnLeftPressed;
	public static event KeyAction OnRightPressed;
	public static event KeyAction OnDownPressed;
	public static event KeyAction OnLeftHeld;
	public static event KeyAction OnRightHeld;
	public static event KeyAction OnDownHeld;

	void Update()
	{
		#region UP
		if (Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.UpArrow)) 
		{
			if (OnUpPressed != null) 
			{
				OnUpPressed ();
			}
		}
		#endregion

		#region DOWN
		if (Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.DownArrow)) 
		{
			if (OnDownPressed != null) 
			{
				OnDownPressed ();
			}
		}

		if(Input.GetKey (KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
		{
			if(OnDownHeld != null)
			{
				OnDownHeld();
			}
		}
		#endregion

		#region LEFT
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
		#endregion

		#region RIGHT
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
		#endregion
	}
}
