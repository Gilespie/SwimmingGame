using Assets.Scripts.Player;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class WaterBoard : MonoBehaviour
{
    [Header("TestUI")]
    [SerializeField] private UITest _ui;

    [Header("Speed")]
    [SerializeField] private float _minSpeed = 1f;
    [SerializeField] private float _maxSpeed = 25f;
    [SerializeField] private float _stopSpeed = 0f;

    [Header("Acceleration")]
    [SerializeField] private float _accelerationLerpRate = 5f;
    [SerializeField] private float _decelerationLerpRate = 2.5f;

    [Header("Delay from collision")]
    [SerializeField] private float _delaySeconds = 4f;

    private Coroutine _currentCoroutine = null;
    private float _currentSpeed = 0f;
    public float CurrentSpeed => _currentSpeed;

    private Vector3 _direction = new();

    [Header("Z Limit")]
    [SerializeField] private float _minBorderLimitsZ = -7;
    [SerializeField] private float _maxBorderLimitsZ = 7;

    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void Start()
    {
        _currentSpeed = _minSpeed;
    }

    private void Update()
    {
        _ui.ShowText(_accelerationLerpRate, _decelerationLerpRate, _maxSpeed, _delaySeconds, _currentSpeed);

        if(_currentSpeed != 0 && _currentCoroutine == null)
        {
            MoveBack();

            if (_playerInput.Gameplay.KeyboardMovementForward.IsPressed() || _playerInput.Gameplay.AccelerationForward.IsPressed()) //"Tap"
            {
                _currentSpeed = Mathf.Lerp(_currentSpeed, _maxSpeed, Time.deltaTime * _accelerationLerpRate);
            }
            else
            {
                _currentSpeed = Mathf.Lerp(_currentSpeed, _minSpeed, Time.deltaTime * _decelerationLerpRate);
            }
        }
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void MoveBack()
    {
        _direction = (-transform.forward).normalized;

        transform.position += _direction * _currentSpeed * Time.deltaTime;

        if (transform.position.z <= _minBorderLimitsZ)
            transform.position = new Vector3(0,-0.5f,_maxBorderLimitsZ);
    }

    public void ChangeAccelerationTest(float amount)
    {
        _accelerationLerpRate = amount;
    }
    public void ChangeDesaccelerationTest(float amount)
    {
        _decelerationLerpRate = amount;
    }
    public void ChangeMxSpeed(float amount)
    {
        _maxSpeed = amount;
    }

    public void ChangeDelay(float amount)
    {
        _delaySeconds = amount;
    }

    public void StartRoutine()
    {
        _currentCoroutine = StartCoroutine(StopMoveWater(_stopSpeed, _delaySeconds));
    }

    private IEnumerator StopMoveWater(float speed, float seconds)
    {
        _currentSpeed = speed;
        yield return new WaitForSeconds(seconds);
        _currentSpeed = _minSpeed;
        _currentCoroutine = null;
        
        yield return null;
    }
}