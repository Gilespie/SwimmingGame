using UnityEngine;

public class Obstacles : MonoBehaviour
{
    private enum TypeOfObstacle
    {
        Static,
        Active
    }

    [SerializeField] private TypeOfObstacle _typeOfObstacle = TypeOfObstacle.Static;
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _speedMovement = 5f;
    [SerializeField] private float _stopOffset = 0.2f;
    //[SerializeField] protected PlayerModel _playerModel;
    private Collider _collider;
    private int _currentWaypoint = 0;
    private Vector3 _direction = new();

    private void Start()
    {
        _collider = GetComponentInChildren<Collider>();    
    }

    private void Update()
    {
        if (_typeOfObstacle == TypeOfObstacle.Static) return;

        switch (_typeOfObstacle)
        {
            case TypeOfObstacle.Static:
                break;
            case TypeOfObstacle.Active:
                ChangeDirection();
                break;
        }
    }

    private void ChangeDirection()
    {
        _direction = (_waypoints[_currentWaypoint].position - transform.position).normalized;

        transform.position += new Vector3(_direction.x,0,_direction.z) * _speedMovement * Time.deltaTime;

        if (Vector3.Distance(transform.position, _waypoints[_currentWaypoint].position) <= _stopOffset)
        {
            _currentWaypoint++;

            if (_currentWaypoint > _waypoints.Length - 1)
            {
                _currentWaypoint = 0;
            }
        }
    }
}