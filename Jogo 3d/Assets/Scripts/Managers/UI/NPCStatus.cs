using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPCStatus : MonoBehaviour
{
    //private Dissolve dissolve;
    //private DamageFlash damageFlash;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Material[] materials;

    public static bool isAlive;

    [Header("-HealthBar-")]
    [SerializeField] private NPCHealthBar HealthBarPrefab;
    private  NPCHealthBar healthBar;
    private float maxHealth = 100f;
    private float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //dissolve = GetComponent<Dissolve>();
        //damageFlash = GetComponent<DamageFlash>();

        currentHealth = maxHealth;

        // Instanciar barra de vida
        healthBar = Instantiate(HealthBarPrefab, transform.position + new Vector3(0, 0, 0), Quaternion.identity);
        healthBar.transform.SetParent(GameObject.Find("DummyCanvas").transform, false);
        healthBar.Initialize(maxHealth);

        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float damageAmount)
    {
        spriteRenderer.material = materials[1];

        //damageFlash.CallDamageFlash();

        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthBar.UpdateHealth(currentHealth);

        if (currentHealth <= 0)
        {
            isAlive = false;
            spriteRenderer.material = materials[2];
            Destroy(healthBar.gameObject);
            //dissolve.CallDissolve();
            

            Debug.Log("Personagem morreu!");
        }
    }
}
