using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using Unity.Burst.CompilerServices;
using UnityEngine;


public class HollowPurple : MonoBehaviour
{
    public GameObject playerPos;
    public PlayerStatus player;
    public GameObject hollowPurplePrefab;
    public ScreenDarkener screenDarkener;
    public bool AnimationFinished;

    public float damage;
    public float manaCost;
    public Transform firePoint;         // Ponto de origem do projétil
    public float darkenDelay = 1f;

    public void Fire()
    {
        player = FindObjectOfType<PlayerStatus>();
        screenDarkener = FindObjectOfType<ScreenDarkener>();

        if (player.currentMana >= manaCost)
        {
            player.currentMana -= manaCost;
            player.manaBar.UpdateStatus(player.currentMana);
            playerPos = GameObject.Find("Player");
            firePoint = playerPos.transform;

            screenDarkener.DarkenScreen();
            
          
            
            
            // Obtém a posição do mouse no mundo 2D
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f; // Garante que fique no mesmo plano

            // Calcula a direção do disparo
            Vector3 shootDirection = (mousePosition - firePoint.position).normalized;

            // Instancia o projétil
            GameObject projectile = Instantiate(hollowPurplePrefab, firePoint.position + new Vector3(2, 0, 0), Quaternion.identity);

            // Define a direção do projétil
            projectile.GetComponent<Projectile>().SetDirection(shootDirection);
            
           
        }
    }

    
    private void Update()
    {
        if (AnimationFinished)
        {
            screenDarkener.LightenScreen();
        }
    }

    
   
    public void DealDamage(GameObject target)
    {
        var tar = target.GetComponent<NPCStatus>();
        if (tar != null)
        {
            tar.TakeDamage(damage);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log($"Colidiu com: {other}");
        DealDamage(other.gameObject);
       

    }
}
