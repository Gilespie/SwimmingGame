using System;
using System.Collections;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    public event Action<bool> OnWin;
    public event Action<bool> OnDead;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private PlayerAvatar _playerAvatar;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private UIPanel _panel;
    [SerializeField] private UIBlind _blindPanel;
    [SerializeField] private float _stunCooldown = 1.5f;
    [SerializeField] private float _slowCooldown = 5f;

    private Victim _targetPoint;
    private Coroutine _currentCoroutine;
    private Collider _collider;
    private int _distanceToTarget = 0;
    private bool _isReached = false;
    private bool _isDead = false;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }

    private void Start()
    {
        transform.position = _startPoint.position;
        _targetPoint = FindObjectOfType<Victim>();
    }

    private void Update()
    {
        CalculateDistance();
    }

    public void StunPlayer()
    {
        StartCoroutine(_playerController.StopMove(_stunCooldown));
        _playerAvatar.ActivateTrigger();
    }

    public void WeakePlayer()
    {
        StartCoroutine(_playerController.SwitchState(_slowCooldown));
    }


    #region OLD

    /*private IEnumerator SlowMoveRoutine()
    {
        _playerController.SwitchState(_slowCooldown);
        _playerController.ChangeSpeed();
        yield return new WaitForSeconds(_slowCooldown);
        _playerController.DefaultSpeed();

        _currentCoroutine = null;

        yield return null;
    }

    public void ActiveStopMove()
    {
        _currentCoroutine = StartCoroutine(StopMoveRoutine());
    }
    public void ActiveSlowMove()
    {
        _currentCoroutine = StartCoroutine(SlowMoveRoutine());
    }

    private IEnumerator StopMoveRoutine()
    {
        _playerController.StopMove(_stunCooldown);
        _playerAvatar.ActivateTrigger();
        _playerController.StopMove();
        _playerController.enabled = false;
        yield return new WaitForSeconds(_stunCooldown);
        _playerController.enabled = true;
        _playerController.StopMove();
        _currentCoroutine = null;

        yield return null;
    }*/
    #endregion

    public void ReachTarget()
    {
        _isReached = true;
        OnWin?.Invoke(_isReached);
    }

    public void GameOver()
    {
        if(_isDead) return;

        _isDead = true;
        OnDead?.Invoke(_isDead);
    }

    private void CalculateDistance()
    {
        _distanceToTarget = Mathf.RoundToInt(Vector3.Distance(transform.position, _targetPoint.transform.position));
        
        if (_distanceToTarget <= 3f)
        {
            _distanceToTarget = 0;
        }

        _panel.ShowDistance(_distanceToTarget);
    }

    public void BlindPlayer()
    {
        _blindPanel.ActivateBlind();
    }
}