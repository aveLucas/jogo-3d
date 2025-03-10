using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;        // Velocidade do projétil
    public float maxDistance = 15f; // Distância máxima que o projétil pode percorrer
    private Vector3 startPosition;  // Posição inicial do projétil
    private Vector3 direction;      // Direção do movimento
    public bool canMove;

    private void Start()
    {
        // Salva a posição inicial para calcular a distância percorrida
        startPosition = transform.position;
    }

    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized;

        // 🔥 Ajusta a rotação do projétil para olhar na direção correta
        transform.rotation = Quaternion.LookRotation(direction);
    }

    private void MoveProjectile()
    {
        if (canMove)
        {
            transform.position += direction * speed * Time.deltaTime;

            // Calcula a distância percorrida
            float traveledDistance = Vector3.Distance(startPosition, transform.position);
            Debug.Log($"Distância percorrida: {traveledDistance}");

            if (traveledDistance >= maxDistance)
            {
                Destroy(gameObject);
            }
        }
    }

    private void Update()
    {
        // Move o projétil na direção em que está apontado
        MoveProjectile();
    }


}
