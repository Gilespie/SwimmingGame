using TMPro;
using UnityEngine;

public class UIText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshPro;

    public void ShowText(float amount)
    {
        textMeshPro.SetText(amount.ToString());
    }
}