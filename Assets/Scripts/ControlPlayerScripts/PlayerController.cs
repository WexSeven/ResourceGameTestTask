using UnityEngine;

public class PlayerController : MonoBehaviour
	{
		private Rigidbody _rigidbody;
		public Joystick virtualJoystick;
		public float speed;
	
		public bool IsStanding()
		{
			if(_rigidbody.velocity == Vector3.zero) return true;
			return false;
		}
		
		protected void Awake()
		{
			_rigidbody = GetComponent<Rigidbody>();
		}
		
		protected void Update()
		{
			if(virtualJoystick.pressed)
			{
				_rigidbody.velocity = virtualJoystick.InputDirection * speed;
				transform.rotation = Quaternion.LookRotation(_rigidbody.velocity, Vector3.up);
			}
			else
			{
				_rigidbody.velocity = Vector3.zero;
			}
		
			//transform.rotation = Quaternion.Euler(new Vector3(0, virtualJoystick.InputDirection.z, 0));
		}
	}
