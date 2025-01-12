using UnityEngine;

public class Logic : MonoBehaviour
{
    [SerializeField] private float _distanceMultiplier = 2f;
    [SerializeField] private float _distanceMax = 1000f;

    [SerializeField] private float _totalTime = 3600f;

    private float _currentDistance = 0f;
    public float CurrentDistance => _currentDistance;

    private float _timer = 0f;
    public float Timer => _timer;

    private void Start()
    {
        _currentDistance = _distanceMax;    
        _timer = _totalTime;
    }

    void Update()
    {
        _currentDistance -= Time.deltaTime * _distanceMultiplier;
        _timer -= Time.deltaTime;
    }
}