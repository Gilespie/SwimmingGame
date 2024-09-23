using UnityEngine;

public class SpawnerObject : MonoBehaviour
{
    [SerializeField] private GameObject[] _obstacles;
    [SerializeField] private int _lineDistance = 2;
    [SerializeField] private float _delaySeconds = 1f;
    private int _randomXRange = 0;
    private float _timer = 0;
    private int _randomIndex = 0;
    

    private void Start()
    {
        _timer = _delaySeconds;
    }

    void Update()
    {
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
        }
        else
        {
            _randomXRange = Random.Range(-1, 2);
            _randomIndex = Random.Range(0, _obstacles.Length);
            GameObject spawnedObj = Instantiate(_obstacles[_randomIndex], new Vector3(_randomXRange*_lineDistance, 0, transform.position.z), Quaternion.identity);
            _timer = _delaySeconds;
        }
    }
}