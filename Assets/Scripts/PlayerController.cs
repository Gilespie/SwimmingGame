using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _minSpeed = 1.0f;
    [SerializeField] private float _maxSpeed = 25.0f;
    [SerializeField] private float _stopSpeed = 0f;

    [SerializeField] private float _moveSide = 5.0f;

    [SerializeField] private float _accelerationLerpRate = 5.0f;
    [SerializeField] private float _decelerationLerpRate = 2.5f;
    [SerializeField] private float _delaySeconds = 4f;

    private float _currentSpeed = 0f;
    private Vector3 _direction = new();
    private Coroutine _currentCoroutine = null;
    private Vector3 _targetPosition = new();
    private Vector3 _startPosition = new();

    private void Start()
    {
        _currentSpeed = _minSpeed;
        //_targetPosition = transform.position;
    }

    private void Update()
    {
        CheckDistance();

        if (_currentCoroutine == null)
        {
            MoveForward();
        }

        if(Input.GetKey(KeyCode.W)) //"Tap"
        {
            _currentSpeed = Mathf.Lerp(_currentSpeed, _maxSpeed, Time.deltaTime / _accelerationLerpRate);
            Debug.Log($"Speed: {_currentSpeed}");
        }
        else
        {
            _currentSpeed = Mathf.Lerp(_currentSpeed, _minSpeed, Time.deltaTime / _decelerationLerpRate);
            Debug.Log($"Speed: {_currentSpeed}");
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if(transform.position.x != -1f)
                transform.position += Vector3.left;
                
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if(transform.position.x != 1f)
                transform.position += Vector3.right;
        }

        //transform.position = Vector3.Lerp(transform.position, Vector3.right, _moveSide * Time.deltaTime);
    }

    private void MoveForward()
    {
        _direction = (transform.forward).normalized;

        transform.position += _direction * _currentSpeed  * Time.deltaTime;
    }

    private void MoveSides()
    {
       
    }

    public void StartRoutine()
    {
        _currentCoroutine = StartCoroutine(MovePlayerRoutine(_stopSpeed, _delaySeconds));
    }

    private IEnumerator MovePlayerRoutine(float speed, float seconds)
    {
        _currentSpeed = speed;
        yield return new WaitForSeconds(seconds);
        _currentCoroutine = null;
        yield return null;
    }

    private void CheckDistance()
    {
        float distance = Vector3.Distance(transform.position, _startPosition);
        Debug.Log($"Distance between start and current position is {distance}");
    }
}
