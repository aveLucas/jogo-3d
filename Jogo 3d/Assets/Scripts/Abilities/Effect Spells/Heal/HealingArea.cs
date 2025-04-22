using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Unity.VisualScripting;
using UnityEngine;

public class HealingArea : MonoBehaviour
{
    public PlayerStatus player;
    public GameObject spellPrefab;
    [SerializeField] private Transform castPosition;
    [SerializeField] private Vector3 offSet;
    public float healingValue = 5f;
    public float manaCost;
    

    public void Cast()
    {
        
        player = FindObjectOfType<PlayerStatus>();
        if (player.currentMana >= manaCost)
        {
            player.currentMana -= manaCost;
            player.manaBar.UpdateStatus(player.currentMana);
            
            castPosition = player.transform;
            GameObject spell = Instantiate(spellPrefab, castPosition.position + offSet, castPosition.rotation);
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        StartCoroutine(Heal());
    }

    IEnumerator Heal()
    {
        float seconds = 1f;

        while (player.currentHealth < player.maxHealth)
        {

            player.currentHealth = Mathf.Min(player.currentHealth + healingValue, player.maxHealth);
            player.healthBar.UpdateStatus(player.currentHealth);

            yield return new WaitForSeconds(seconds);
                
            Debug.Log($"heal: {healingValue}");            
        }
        
    }
}
