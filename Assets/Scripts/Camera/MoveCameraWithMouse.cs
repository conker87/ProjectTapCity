using UnityEngine;
using System.Collections;

public class MoveCameraWithMouse : MonoBehaviour {

	public float mouseSensitivity = .5f;
	private Vector3 lastPosition;

	void Update()
	{
		if (Input.GetMouseButtonDown(0)) {
			
			lastPosition = Input.mousePosition;

		}

		if (Input.GetMouseButton(0))
		{
			
			Vector3 delta = Input.mousePosition - lastPosition;
			Vector3.Lerp(lastPosition, new Vector3(-delta.x * mouseSensitivity, -delta.y * mouseSensitivity, 0), 1f);

			lastPosition = Input.mousePosition;

		}
	}
}
