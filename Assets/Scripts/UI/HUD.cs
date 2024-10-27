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
        HideAllPaneles();
        ShowPanel(_hudPanel);
        Time.timeScale = 1.0f;
    }

    public void ShowPause()
    {
        HideAllPaneles();
        ShowPanel(_pausePanel);
        Time.timeScale = 0.0f;
    }

    public void ShowSettings()
    {
        HideAllPaneles();
        ShowPanel(_settingsPanel);
    }

    public void ShowPanel(GameObject panel)
    {
        if(panel != null)
        {
            panel.SetActive(true);
        }
    }

    public void HideAllPaneles()
    {
        _hudPanel.SetActive(false);
        _pausePanel.SetActive(false);
        _settingsPanel.SetActive(false);
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