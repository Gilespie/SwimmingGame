using TMPro;
using UnityEngine;

public class UITest : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _slider1;
    [SerializeField] private TextMeshProUGUI _slider2;
    [SerializeField] private TextMeshProUGUI _slider3;
    [SerializeField] private TextMeshProUGUI _slider4;
    [SerializeField] private TextMeshProUGUI _slider5;

    public void ShowText(float amount1, float amount2, float amount3, float amount4, float amount5)
    {
        _slider1.SetText(amount1.ToString());
        _slider2.SetText(amount2.ToString());
        _slider3.SetText(amount3.ToString());
        _slider4.SetText(amount4.ToString());
        _slider5.SetText(amount5.ToString());
    }
}