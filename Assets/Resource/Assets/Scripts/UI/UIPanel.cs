using TMPro;
using UnityEngine;

public class UIPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _distanceText;
    [SerializeField] private TextMeshProUGUI _timerText;

    public void ShowDistance(int distance)
    {
        _distanceText.SetText($"Distance: {distance:D4}m");
    }

    public void ShowTime(int minutes, int seconds)
    {
        _timerText.SetText($"Time: {minutes:00}:{seconds:00}");
    }
}
