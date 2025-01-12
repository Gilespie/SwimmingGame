using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelConditions : MonoBehaviour
{
    [SerializeField] private string _levelName = "Level1";
    [SerializeField] private PlayerModel _playerModel;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _loosePanel;

    private void Awake()
    {
        _playerModel = FindObjectOfType<PlayerModel>();
    }

    private void OnEnable()
    {
        _playerModel.OnWin += OnWin;
        _playerModel.OnDead += OnDead;
    }

    private void Start()
    {
        _winPanel.SetActive(false);
        _loosePanel.SetActive(false);
    }

    private void OnDisable()
    {
        _playerModel.OnWin -= OnWin;
        _playerModel.OnDead -= OnDead;
    }

    private void OnWin(bool isReached)
    {
        if (isReached)
        {
            _winPanel.SetActive(true);
        }
    }

    private void OnDead(bool isDead)
    {
        if (isDead)
        {
            _loosePanel.SetActive(true);
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(_levelName);
    }
}
