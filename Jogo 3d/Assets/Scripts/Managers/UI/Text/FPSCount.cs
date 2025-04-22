using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FPSCount : MonoBehaviour
{
    [SerializeField, Range(0.1f, 1.5f)] private float updateRate = 1.5f;
    private float fpsQuantity;
    [SerializeField] private TMP_Text fpsText;


    private void Start()
    {
        InvokeRepeating(nameof(CountFPS), 0f, updateRate);
    }

    private void OnValidate()
    {
        // Arredondar o valor para múltiplos de 0.1
        updateRate = Mathf.Round(updateRate * 10f) / 10f;
    }

    private void CountFPS()
    {
        fpsQuantity = 1f / Time.deltaTime;
        fpsText.text = Mathf.Floor(fpsQuantity).ToString() + " FPS";
    }
}
