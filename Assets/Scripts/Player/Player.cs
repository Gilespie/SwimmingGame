using Assets.Scripts.Configs;
using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerConfig _config;

        private PlayerInput _input;
        private SwipeController _swipeController;

        public PlayerInput Input => _input;

        public PlayerConfig Config => _config;

        private void Awake() => _input = new PlayerInput();

        private void Start() => _swipeController = new SwipeController(this);
        private void OnEnable() => _input.Enable();

        private void OnDisable() => _input.Disable();
    }
}