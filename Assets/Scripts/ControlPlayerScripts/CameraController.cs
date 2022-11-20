using UnityEngine;

public class CameraController : MonoBehaviour
	{
		private Transform _player;
	
		protected void Awake()
		{
			_player = GameObject.FindGameObjectWithTag("Player").transform;
		}
	
		protected void Update()
		{
			Vector3 position = _player.position;
			transform.position = new Vector3(position.x, transform.position.y, position.z - 6);
		}
	}
