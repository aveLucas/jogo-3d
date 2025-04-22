using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;  
    public float distance = 3f;  
    public float sensitivity = 2f;  
    public float minY = -40f, maxY = 80f; 

    private float rotX = 0f, rotY = 0f;

    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked; 
        
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
            CalculateRotation();
        }
        
    }
    private void CalculateRotation()
    {
        // Calcula rotação da câmera
        Quaternion rotation = Quaternion.Euler(rotX, rotY, 0);
        Vector3 position = target.position - (rotation * Vector3.forward * distance);

        transform.position = position;
        // Faz a câmera olhar horizontalmente para o alvo, sem inclinar
        Vector3 lookTarget = target.position + Vector3.up * 1.5f; // Ajuste a altura se necessário
        transform.LookAt(lookTarget);

        target.rotation = Quaternion.Euler(0, rotY, 0);
    }

    public void SetRotation(Vector3 eulerAngles)
    {
        rotY = eulerAngles.y;
        rotX = Mathf.Clamp(eulerAngles.x, minY, maxY); // Proteção, mesmo que geralmente só o Y seja útil
    }
    public Vector3 GetRotation()
    {
        return new Vector3(rotX, rotY, 0f);
    }

}
