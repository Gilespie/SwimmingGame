using System;
using DG.Tweening;
using UnityEngine.InputSystem;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class SwipeController
    {
        private readonly Player _player;

        private const int MaxLine = 1;

        private float _xDirection = 0;

        private int _currentLine = 0;

        private Vector3[] _positions =
        {
            Vector3.left,
            Vector3.zero,
            Vector3.right
        };

        private Vector2 _startTouchPosition;
        private Vector2 _currentTouchPosition;

        private bool _isSwipe = true;

        public SwipeController(Player player)
        {
            _player = player;

            _player.Input.Gameplay.KeyboardMovementSides.performed += OnSide;
            _player.Input.Gameplay.Swipe.started += OnTouchStarted;
            _player.Input.Gameplay.Swipe.performed += OnTouchMoved;
        }

        ~SwipeController()
        {
            _player.Input.Gameplay.KeyboardMovementSides.performed -= OnSide;
            _player.Input.Gameplay.Swipe.started += OnTouchStarted;
            _player.Input.Gameplay.Swipe.performed -= OnTouchMoved;
        }

        private void OnTouchStarted(InputAction.CallbackContext context)
        {
            _startTouchPosition = context.ReadValue<Vector2>();
        }

        private void OnTouchMoved(InputAction.CallbackContext context)
        {
            if (!_isSwipe) return;

            _currentTouchPosition = context.ReadValue<Vector2>();

            DetectSwipe();
        }

        private void OnSide(InputAction.CallbackContext context)
        {
            _xDirection = context.ReadValue<float>();

            int targetLine = (_xDirection > 0) ? (_currentLine + 1) : (_currentLine - 1);

            if (targetLine >= -MaxLine && targetLine <= MaxLine)
            {
                _currentLine = targetLine;
                MoveTo(targetLine);
            }
        }

        private void DetectSwipe()
        {
            var direction = (_currentTouchPosition.x - _startTouchPosition.x);

            if (MathF.Abs(direction) >= _player.Config.SwipeThreshold)
            {
                int targetLine = (direction > 0) ? (_currentLine + 1) : (_currentLine - 1);

                if (targetLine >= -MaxLine && targetLine <= MaxLine)
                {
                    _currentLine = targetLine;
                    MoveTo(targetLine);

                    _startTouchPosition = _currentTouchPosition;
                }
            }
        }

        private void MoveTo(int line)
        {
            _isSwipe = false;
            var targetPosition = _positions[line + 1] * _player.Config.LineDistance;

            _player.transform.DOMoveX(targetPosition.x, _player.Config.DurationMoving).OnComplete(() => _isSwipe = true);
        }
    }
}
