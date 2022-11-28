using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
	public delegate void CursorDelegate(bool cursorState);
	public static CursorDelegate cursorDelegate;

	private void Start()
	{
		//Cursor.visible = false;
		//Cursor.lockState = CursorLockMode.Locked;
		cursorDelegate = CaptureMouse;
	}

	public void CaptureMouse(bool cursorState)
	{

		if (cursorState)
		{
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
		}
		if(!cursorState)
		{
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.Confined;
		}
	}
}
