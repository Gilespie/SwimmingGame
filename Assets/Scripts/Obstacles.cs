using UnityEngine;
using Assets.Scripts.Player;

public class Obstacles : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f;
    private WaterBoard _board;
    private Vector3 _direction = new();
    private float _limitZ = 7;

    private void Start()
    {
        _board = FindObjectOfType<WaterBoard>();
    }

    private void Update()
    {
        _speed = _board.CurrentSpeed;

        _direction = new Vector3(0,0,-1).normalized;

        transform.position += _direction * _speed * Time.deltaTime;

        if (transform.position.z <= -_limitZ)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<Player>(out Player player))
        {
            _board.StartRoutine();
            Destroy(gameObject);    
        }
    }
}