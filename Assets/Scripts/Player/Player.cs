using Assets.Scripts.Configs;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerConfig _config;

        private const float Duration = 1f;
        private PlayerInput _input;

        private Vector2 _startTouchPosition;
        private Vector2 _endTouchPosition;

        private Vector3[] _positions =
        {
            Vector3.left,
            Vector3.zero,
            Vector3.right
        };

        private int _currentLine = 0;

        private bool _isSwipe;

        private void Awake() => _input = new PlayerInput();

        private void Start() => _isSwipe = true;

        private void OnEnable()
        {
            _input.Enable();
            _input.Gameplay.Swipe.started += OnTouchStarted;
            _input.Gameplay.Swipe.canceled += OnTouchEnded;
        }

        private void OnDisable()
        {
            _input.Disable();
            _input.Gameplay.Swipe.started -= OnTouchStarted;
            _input.Gameplay.Swipe.canceled -= OnTouchEnded;
        }

        private void OnTouchStarted(InputAction.CallbackContext context)
        {
            var touch = Touchscreen.current.primaryTouch;

            _startTouchPosition = touch!.position.ReadValue();
        }

        private void OnTouchEnded(InputAction.CallbackContext context)
        {
            var touch = Touchscreen.current.primaryTouch;

            _endTouchPosition = touch!.position.ReadValue();

            DetectSwipe();
        }

        private void DetectSwipe()
        {
            if (!_isSwipe) return;

            var direction = _endTouchPosition.x - _startTouchPosition.x;

            if (MathF.Abs(direction) >= _config.SwipeThreshold)
            {
                int targetLine = (direction > 0) ? (_currentLine + 1) : (_currentLine - 1);

                if (targetLine >= -1 && targetLine <= 1)
                {
                    _currentLine = targetLine;
                    StartCoroutine(MoveTo(targetLine));
                }
            }
        }

        private IEnumerator MoveTo(int line)
        {
            _isSwipe = false;

            var startPosition = transform.position;
            var targetPosition = _positions[line + 1] * _config.LineDistance;

            var time = 0f;

            while (time < Duration)
            {
                transform.position = Vector3.Lerp(startPosition, targetPosition, time);

                time += Time.deltaTime / _config.DurationMoving;
                yield return null;
            }

            _isSwipe = true;
        }
    }
}
