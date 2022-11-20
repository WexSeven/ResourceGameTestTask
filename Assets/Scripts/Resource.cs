using UnityEngine;

public class Resource : MonoBehaviour
{
	[SerializeField]private string _title;
	private bool _moving;
	private Transform _target;
	
	public string Title => _title;
	public bool IsMoving => _moving;
	
	public void MoveTo(Transform selectedTransform)
	{
		_moving = true;
		_target = selectedTransform;
	}
	
	public bool IsEqual(Resource resourse)
	{
		if(resourse.Title.Equals(Title)) return true;
		return false;
	}
	
	protected void FixedUpdate()
	{
		if(_moving)
		{
			Vector3 position = _target.position;
			Vector3 targetPosition = new Vector3(position.x, position.y + 0.6f, position.z);
			transform.SetPositionAndRotation(Vector3.MoveTowards(transform.position, targetPosition, 0.3f), Quaternion.Lerp(transform.rotation, _target.rotation, 1f));
			if(transform.position == targetPosition) _moving = false;
			if(!_moving)
			{
				transform.SetParent(_target);
				_target = null;
			}
		}
	}
}
