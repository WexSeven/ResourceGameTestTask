using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Tooltip("Virtual Joystick on scene")] [SerializeField]
    private Joystick _virtualJoystick;

    [Tooltip("Speed of the player")] [SerializeField]
    private float _speed;

    private Rigidbody _rigidbody;

    public bool IsStanding()
    {
        return !_virtualJoystick.Pressed;
    }

    protected void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    protected void Update()
    {
        if (_virtualJoystick.Pressed)
        {
            _rigidbody.velocity = _virtualJoystick.InputDirection * _speed;
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity, Vector3.up);
        }
        else
        {
            _rigidbody.velocity = Vector3.zero;
        }
    }
}