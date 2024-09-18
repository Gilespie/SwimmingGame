using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _lerpRate = 3f;
    [SerializeField] private Vector3 _cameraOffset = new(0,4,0);

    void Update()
    {
        if(_target != null)
        {
            transform.position = Vector3.Lerp(transform.position, _target.position + _cameraOffset, _lerpRate * Time.deltaTime);
        }
    }
}