using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 20f;
    public float lifetime = 5f;  // Tempo at� a bola de fogo desaparecer
    public float damage = 10f;
    public float manaCost = 10f;

    private Vector3 direction;

    public GameObject fireballPrefab;  // Prefab da bola de fogo
    public Transform firePoint;

    private PlayerStatus player;

    public void ShootFireball()
    {
        player = FindObjectOfType<PlayerStatus>();
        if(player.currentMana >= manaCost )
        {
            firePoint = GameObject.Find("FirePoint").transform;

            player.currentMana -= manaCost;
            player.manaBar.UpdateStatus(player.currentMana);

            // Instancia a bola de fogo na posi��o e rota��o do firePoint
            GameObject fireball = Instantiate(fireballPrefab, firePoint.position, Quaternion.identity);

            // Calcula a dire��o do disparo baseado na c�mera do jogador
            Vector3 fireDirection = Camera.main.transform.forward;

            // Obt�m o script da bola de fogo e define a dire��o
            Fireball fireballScript = fireball.GetComponent<Fireball>();
            fireballScript.SetDirection(fireDirection);
        }
    }

    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized;  // Normaliza para manter velocidade constante

        //Destroy(gameObject, lifetime);  // Destroi a bola de fogo ap�s um tempo
        
    }

    void Update()
    {
        // Move a bola de fogo na dire��o definida
        transform.position += direction * speed * Time.deltaTime;
        float traveledDistance = Vector3.Distance(firePoint.position, transform.position);
        Debug.Log(traveledDistance);
        if(traveledDistance >= lifetime ) 
        {
            Destroy(gameObject);
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

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Colidiu com: {other.gameObject.name}");
        DealDamage(other.gameObject);
        Destroy(gameObject);
    }
}
