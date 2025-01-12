using UnityEngine;

public class Shark : MonoBehaviour
{
    [SerializeField] private string _nameTrigger = "onAttack";
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _rayDistance = 35f;
    [SerializeField] private float _offset = 0.2f;
    private Animator _animator;
    private Collider _collider;
    private Rigidbody _rb;
    private RaycastHit _hit;
    private Vector3 _direction = new();
    private Vector3 _targetPosition = new();

    private void Awake()
    {
        _collider = GetComponent<Collider>();
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponentInChildren<Animator>();
    }

    private void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, _rayDistance))
        {
            if (hit.collider.TryGetComponent<PlayerModel>(out PlayerModel player))
            {
                _targetPosition = hit.point;
                MoveToTarget(_targetPosition);

                if(Vector3.Distance(_targetPosition, transform.position) <= _offset)
                {
                    _animator.SetTrigger(_nameTrigger);
                    return;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<PlayerModel>(out PlayerModel player))
        {
            //player.ActiveStopMove();
            //player.GameOver();
        }
        if(other.TryGetComponent<Wall>(out Wall wall))
        {
            _animator.SetTrigger("");
        }
    }

    private void MoveToTarget(Vector3 target)
    {
        _direction = (target - transform.position).normalized;
        _rb.velocity = _direction * _speed * Time.fixedDeltaTime;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * _rayDistance);
    }
}