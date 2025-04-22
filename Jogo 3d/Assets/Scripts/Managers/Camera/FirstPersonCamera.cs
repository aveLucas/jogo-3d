using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public float mouseSensitivity = 100f;  // Sensibilidade do mouse
    public Transform playerBody;  // Refer�ncia ao corpo do jogador

    private float xRotation = 0f;  // Armazena a rota��o no eixo X
    // Start is called before the first frame update
    void Start()
    {
        
        Cursor.lockState = CursorLockMode.Locked; // Trava o cursor no centro da tela
        
    }

    // Update is called once per frame
    void Update()
    {
        // Captura movimento do mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Controla a rota��o vertical da c�mera (evita virar de ponta cabe�a)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Aplica rota��o na c�mera
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotaciona o corpo do jogador no eixo Y
        playerBody.Rotate(Vector3.up * mouseX);
    }
    public void SetRotation(Vector3 eulerAngles)
    {
        xRotation = Mathf.Clamp(eulerAngles.x, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

}
