using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
	// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
	protected void FixedUpdate()
	{
		Quaternion rotation = GameManager.mainCamera.transform.rotation;
		transform.LookAt(transform.position + rotation * Vector3.back, rotation * Vector3.up);
	}
}
