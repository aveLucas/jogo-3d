using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletType : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float damage;
    public float manaCost;
    public Transform firePoint; // Local de origem do proj�til
    private PlayerStatus player;
    

    

    public void Fire()
    {
        player = FindObjectOfType<PlayerStatus>(); // Encontra o PlayerStatus na cena
        if (player == null) return; // Se o player n�o foi encontrado, sai da fun��o

        if (player.currentMana >= manaCost)
        {
            // Consome mana
            player.currentMana -= manaCost;
            player.manaBar.UpdateStatus(player.currentMana);
            firePoint = GameObject.Find("FirePoint").transform;
            

            // Obt�m um raio da c�mera at� a posi��o do mouse
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
            RaycastHit hit;

            Vector3 shootDirection;

            if (Physics.Raycast(ray, out hit))
            {
                // Se o raio atinge algo, atira na dire��o do ponto atingido
                shootDirection = hit.point;
            }
            else
            {
                // Caso contr�rio, atira para frente (caso n�o haja colis�o com nada)
                shootDirection = firePoint.forward;
            }

            // Instancia o proj�til
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

            // Define a dire��o do proj�til
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
    
