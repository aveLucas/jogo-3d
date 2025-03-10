using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenDarkener : MonoBehaviour
{
    private Image overlay;
    public float fadeDuration = 0.5f; // Tempo de fade

    void Awake()
    {
        overlay = GetComponent<Image>();
    }

    public void DarkenScreen()
    {
        StartCoroutine(FadeTo(0.8f)); // Escurece para 70% de opacidade
    }

    public void LightenScreen()
    {
        StartCoroutine(FadeTo(0f)); // Retorna ao normal
    }

    private IEnumerator FadeTo(float targetAlpha)
    {
        float startAlpha = overlay.color.a;
        
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / fadeDuration);
            overlay.color = new Color(0, 0, 0, newAlpha);
            yield return null;
        }

        overlay.color = new Color(0, 0, 0, targetAlpha);
    }
}

