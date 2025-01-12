using UnityEngine;

public class Victim : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private UIPanel _panel;
    [SerializeField] private PlayerModel _playerModel;
    [SerializeField] private ParticleSystem _splashesPS;
    private string _triggerName = "onDead";
    private Animator _animator;
    private float _currentHealth = 0;
    private float _timer;
    private bool _isSaved = false;
    private bool _isDead = false;

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _currentHealth = _maxHealth;
        _timer = _currentHealth;
    }

    private void Update()
    {
        if (_isSaved) return;

        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
            CalculateTime();
        }
        else
        {
            if (!_isDead)
            {
                _playerModel.GameOver();
                _animator.SetTrigger(_triggerName);
                _splashesPS.Stop();
                _isDead = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerModel>(out PlayerModel player))
        {
            _isSaved = true;
            player.ReachTarget();
        }
    }

    private void CalculateTime()
    {
        int minutes = Mathf.FloorToInt(_timer / 60);
        int seconds = Mathf.FloorToInt(_timer % 60);

        _panel.ShowTime(minutes,seconds);
    }
}