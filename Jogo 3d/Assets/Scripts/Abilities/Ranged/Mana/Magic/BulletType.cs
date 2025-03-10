using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletType : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float damage;
    public float manaCost;
    public Transform firePoint; // Local de origem do projétil
    private PlayerStatus player;
    

    

    public void Fire()
    {
        player = FindObjectOfType<PlayerStatus>(); // Encontra o PlayerStatus na cena
        if (player == null) return; // Se o player não foi encontrado, sai da função

        if (player.currentMana >= manaCost)
        {
            // Consome mana
            player.currentMana -= manaCost;
            player.manaBar.UpdateStatus(player.currentMana);
            firePoint = GameObject.Find("FirePoint").transform;
            

            // Obtém um raio da câmera até a posição do mouse
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
            RaycastHit hit;

            Vector3 shootDirection;

            if (Physics.Raycast(ray, out hit))
            {
                // Se o raio atinge algo, atira na direção do ponto atingido
                shootDirection = hit.point;
            }
            else
            {
                // Caso contrário, atira para frente (caso não haja colisão com nada)
                shootDirection = firePoint.forward;
            }

            // Instancia o projétil
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

            // Define a direção do projétil
            projectile.GetComponent<Projectile>().SetDirection(shootDirection);
            projectile.GetComponent<Projectile>().canMove = true;
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
    
