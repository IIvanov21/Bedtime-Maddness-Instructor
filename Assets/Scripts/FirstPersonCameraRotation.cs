using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A simple FPP (First Person Perspective) camera rotation script.
/// Like those found in most FPS (First Person Shooter) games.
/// </summary>
public class FirstPersonCameraRotation : MonoBehaviour
{

	
	const string xAxis = "Mouse X"; //Strings in direct code generate garbage, storing and re-using them creates no garbage
	const string yAxis = "Mouse Y";

	[SerializeField]
	GameObject mainCamera;

	public float mouseSensitivity = 500.0f;

	float xRotation = 0.0f;

    private void Start()
    {
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
	{
		float mouseX = Input.GetAxis(xAxis) * mouseSensitivity * Time.deltaTime;
		float mouseY = Input.GetAxis(yAxis) * mouseSensitivity * Time.deltaTime;

		xRotation -= mouseY;
		xRotation= Mathf.Clamp(xRotation, -90.0f, 90.0f);

		transform.Rotate(Vector3.up * mouseX);
		mainCamera.transform.localRotation=Quaternion.Euler(xRotation, 0.0f, 0.0f);
	}
}
