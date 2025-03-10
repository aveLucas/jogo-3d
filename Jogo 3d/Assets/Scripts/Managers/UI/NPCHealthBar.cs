using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NPCHealthBar : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private GameObject target;
    [SerializeField] private Vector3 offSet;

    private void Awake()
    {
        
        target = GameObject.FindGameObjectWithTag("Enemy");
    }
    public void Initialize(float maxHealth)
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
    }

    public void UpdateHealth(float currentHealth)
    {
        healthSlider.value = currentHealth;
    }

    public void Update()
    {
        transform.rotation = Camera.main.transform.rotation;
        transform.position = target.transform.position + offSet;
    }
}
