using UnityEngine;

public class PlayerAvatar : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private string _hitTrigger = "OnHit";
    [SerializeField] private string _speedName = "Speed";

    public void ActivateTrigger()
    {
        _animator.SetTrigger(_hitTrigger);
    }

    public void ChangeSpeed(float speed)
    {
        _animator.SetFloat(_speedName, speed);
    }
}