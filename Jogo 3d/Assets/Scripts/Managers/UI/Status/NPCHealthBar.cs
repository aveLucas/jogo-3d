using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NPCHealthBar : MonoBehaviour
{
    [SerializeField] private Slider healthImage;
    [SerializeField] private GameObject target;
    [SerializeField] private Vector3 offSet;
    private Transform myCamera;

    private void Awake()
    {
        myCamera = Camera.main.transform;
        target = GameObject.FindGameObjectWithTag("Dummy");
    }
    public void Initialize(float maxHealth)
    {
        healthImage.maxValue = maxHealth;
        healthImage.value = maxHealth;
    }

    public void UpdateHealth(float currentHealth)
    {
        healthImage.value = currentHealth;
    }

    private void Update()
    {
        Vector3 direction = transform.position - myCamera.position;
        direction.y = 0f;
        transform.rotation = Quaternion.LookRotation(direction);

        transform.position = target.transform.position + offSet;
    }
}
