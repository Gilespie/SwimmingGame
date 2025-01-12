using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 4f;
    [SerializeField] private float _speedSlow = 1.5f;
    [SerializeField] private float _rotationSpeed = 720.0f;
    [SerializeField] private float _decelerationRate = 5f;
    [SerializeField] private float _acelerationRate = 5f;
    [SerializeField] private VirtualJoystick _joystick;
    [SerializeField] private PlayerAvatar _playerAvatar;
    private float _stopSpeed = 0f;
    private Vector3 _direction = new();
    private float _currentSpeed = 0f;
    private Rigidbody _rigidbody;
    private bool _isSlowed;
    private bool _isStuned;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _direction = new Vector3(_joystick.Horizontal(), 0, _joystick.Vertical());
    }

    private void FixedUpdate()
    {
        if (_direction.magnitude > 0.1f && !_isStuned)
        {
            if (!_isSlowed)
            {
                MovePlayer(_speed);
                RotatePlayer();
            }
            else
            {
                MovePlayer(_speedSlow);
                RotatePlayer();
            }
        }
        else
        {
            _currentSpeed = Mathf.Lerp(_currentSpeed, 0f, Time.fixedDeltaTime * _decelerationRate);
            //_currentSpeed -= _decelerationRate * Time.fixedDeltaTime;

            if (_currentSpeed < 0.01f)
                _currentSpeed = 0f;
        }

        _playerAvatar.ChangeSpeed(_currentSpeed);
    }

    private void MovePlayer(float speed)
    {
        _rigidbody.MovePosition(transform.position + _direction * speed * Time.fixedDeltaTime);
        _currentSpeed = Mathf.Lerp(_currentSpeed, speed * _direction.magnitude, Time.fixedDeltaTime * _acelerationRate);
        //_rigidbody.AddForce(_direction * _speed * Time.fixedDeltaTime, ForceMode.Impulse);
    }

    private void RotatePlayer()
    {
        Quaternion targetRotation = Quaternion.LookRotation(_direction);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.fixedDeltaTime);
    }

    public void StopMove()
    {
        _currentSpeed = _stopSpeed;
    }

    public void ChangeSpeed()
    {
        _currentSpeed = _speedSlow;
    }

    public void DefaultSpeed()
    {
        _currentSpeed = _speed;
    }

    public IEnumerator SwitchState(float seconds)
    {
        if (_isSlowed) yield return null;

        _isSlowed = true;
        yield return new WaitForSeconds(seconds);
        _isSlowed = false;
    }

    public IEnumerator StopMove(float seconds)
    {
        if(_isStuned) yield return null;

        _isStuned = true;
        yield return new WaitForSeconds(seconds);
        _isStuned = false;
    }
}