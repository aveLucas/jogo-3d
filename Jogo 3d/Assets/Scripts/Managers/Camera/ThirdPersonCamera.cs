using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;  // O jogador
    public float distance = 3f;  // Distância da câmera
    public float sensitivity = 2f;  // Sensibilidade do mouse
    public float minY = -40f, maxY = 80f;  // Limites de rotação vertical

    private float rotX = 0f, rotY = 0f;

    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked; // Trava o cursor no centro da tela
        
    }

    void Update()
    {
        // Captura movimento do mouse
        rotX -= Input.GetAxis("Mouse Y") * sensitivity;
        rotY += Input.GetAxis("Mouse X") * sensitivity;
        rotX = Mathf.Clamp(rotX, minY, maxY);
    }

    void LateUpdate()
    {
        if(GameManager.isPaused != true)
        {
            // Calcula rotação da câmera
            Quaternion rotation = Quaternion.Euler(rotX, rotY, 0);
            Vector3 position = target.position - (rotation * Vector3.forward * distance);

            // Aplica posição e rotação da câmera
            transform.position = position;
            transform.LookAt(target.position);

            // 🔥 Aqui garantimos que o jogador sempre olhe para frente quando na terceira pessoa
            target.rotation = Quaternion.Euler(0, rotY, 0);
        }
        
    }
}
