using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//using DG.Tweening;

public class StatusBar : MonoBehaviour
{
    [SerializeField] private Slider statusSlider;
    [SerializeField] private Image trailBar;
    [SerializeField] private float trailDelay = 0.4f;
    //[SerializeField] private Image statusImage;
    public Gradient gradient;
    public Image gradientImage;
    [SerializeField] private TMP_Text valueText;
    private  float maxValueText;
    
    
    public void Initialize( float maxValue )
    {
        maxValueText = maxValue;
        //statusImage.fillAmount = maxValue;
        valueText.text = $" {maxValue.ToString()} / {maxValue}";
        statusSlider.maxValue = maxValue;
        statusSlider.value = maxValue;

        //trailBar.fillAmount = maxValue;
        

        if(gradientImage != null)
        {
            gradientImage.color = gradient.Evaluate(1f);
        }
    }

    public void UpdateStatus(float currentValue)
    {
        //statusImage.fillAmount = currentValue / 100;
        valueText.text = $" {currentValue.ToString()} / {maxValueText}";
        statusSlider.value = currentValue;

        //StartCoroutine(TrailBar());
        /*Sequence sequence = DOTween.Sequence();

        sequence.AppendInterval(trailDelay);
        sequence.Append(trailBar.DOFillAmount(statusSlider.normalizedValue, 0.3f))
            .SetEase(Ease.InOutSine);*/
        

        if(gradientImage != null)
        {
            gradientImage.color = gradient.Evaluate(statusSlider.normalizedValue);
        }
        
        
    }

    
  
}
