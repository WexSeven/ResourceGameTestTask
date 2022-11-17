using UnityEngine;

public class Resource : MonoBehaviour
{
	public string title;
	public bool moving;
	public Transform target;
	
	public void MoveTo(Transform selectedTransform)
	{
		moving = true;
		target = selectedTransform;
	}
	
	protected void FixedUpdate()
	{
		if(moving)
		{
			Vector3 position = target.position;
			Vector3 targetPosition = new Vector3(position.x, position.y + 0.6f, position.z);
			transform.position = Vector3.MoveTowards(transform.position, targetPosition, 0.3f);
			transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, 1f);
			if(transform.position == targetPosition) moving = false;
			if(!moving)
			{
				transform.SetParent(target);
				target = null;
			}
		}
	}
}
