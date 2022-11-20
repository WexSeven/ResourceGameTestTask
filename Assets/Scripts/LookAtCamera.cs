using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
	protected void FixedUpdate()
	{
		Quaternion rotation = GameManager.Instance.MainCamera.transform.rotation;
		transform.LookAt(transform.position + rotation * Vector3.back, rotation * Vector3.up);
	}
}
