using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIBlind : MonoBehaviour
{
    [SerializeField] private Image _blindImage;
    [SerializeField] private float _fadeDuration = 2.0f;
    [SerializeField] private float _waitTime = 5f;
    private Coroutine _currentCoroutine = null;

    public void ActivateBlind()
    {
        if (_currentCoroutine == null)
        {
            _currentCoroutine = StartCoroutine(BlindRoutine());
        }
    }

    private IEnumerator BlindRoutine()
    {
        yield return StartCoroutine(FadeAlpha(0f, 1f));

        yield return new WaitForSeconds(_waitTime);

        yield return StartCoroutine(FadeAlpha(1f, 0f));

        _currentCoroutine = null;

        yield return null;
    }

    private IEnumerator FadeAlpha(float startAlpha, float targetAlpha)
    {
        float elapsed = 0f;
        Color currentColor = _blindImage.color;

        while (elapsed < _fadeDuration)
        {
            elapsed += Time.deltaTime;

            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, elapsed / _fadeDuration);
            _blindImage.color = new Color(currentColor.r, currentColor.g, currentColor.b, newAlpha);

            yield return null;
        }

        _blindImage.color = new Color(currentColor.r, currentColor.g, currentColor.b, targetAlpha);
    }
}