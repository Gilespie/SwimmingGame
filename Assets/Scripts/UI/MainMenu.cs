using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string _firstLevel = "Level1";
    public void StartLevel()
    {
        SceneManager.LoadScene(_firstLevel);
    }
}