using UnityEngine;
using TMPro;

public class Statistic : MonoBehaviour
{
    [SerializeField] private Logic _logic;
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private TextMeshProUGUI _distanceText;
    private float _time = 0f;
    
    void Update()
    {
        ShowTime();
        ShowDistance();
    }

    private void ShowTime()
    {
        _time = _logic.Timer;

        int minutes = Mathf.FloorToInt(_time / 60);
        int seconds = Mathf.FloorToInt(_time % 60);
        _timerText.SetText($"{minutes:00}:{seconds:00}");
    }

    private void ShowDistance()
    {
        _distanceText.SetText($"{Mathf.RoundToInt(_logic.CurrentDistance)}m");
    }
}
