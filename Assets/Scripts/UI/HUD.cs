using UnityEngine;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{
    [SerializeField] private GameObject _hudPanel;
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _settingsPanel;
    private string _currentScene;

    void Start()
    {
        ShowHUDMain();
    }

    public void ShowHUDMain()
    {
        _hudPanel.SetActive(true);
        _pausePanel.SetActive(false);
        _settingsPanel.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void ShowPause()
    {
        _hudPanel.SetActive(false);
        _pausePanel.SetActive(true);
        _settingsPanel.SetActive(false);
        Time.timeScale = 0.0f;
    }

    public void ShowSettings()
    {
        _hudPanel.SetActive(false);
        _pausePanel.SetActive(false);
        _settingsPanel.SetActive(true);
    }

    public void RestartLevel()
    {
        _currentScene = SceneManager.GetActiveScene().name;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(_currentScene);
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Menu");
    }
}