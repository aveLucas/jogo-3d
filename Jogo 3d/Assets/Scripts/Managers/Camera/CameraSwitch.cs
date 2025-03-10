using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject firstPersonCamera;  // Câmera de primeira pessoa
    public GameObject thirdPersonCamera;  // Câmera de terceira pessoa
    public Transform player;  // Referência ao jogador
    public ThirdPersonCamera thirdPersonCameraScript;  // Script da câmera de terceira pessoa

    private bool isFirstPerson = true;

    void Start()
    {
        SwitchToFirstPerson();
    }

    void Update()
    {
        if (GameManager.isPaused != true && Input.GetKeyDown(KeyCode.F5)) // Tecla para trocar a câmera
        {
            isFirstPerson = !isFirstPerson;

            if (isFirstPerson)
                SwitchToFirstPerson();
            else
                SwitchToThirdPerson();
        }
    }

    void SwitchToFirstPerson()
    {
        firstPersonCamera.SetActive(true);
        thirdPersonCamera.SetActive(false);
        thirdPersonCameraScript.enabled = false;  // Desativa rotação livre da câmera de terceira pessoa
    }

    void SwitchToThirdPerson()
    {
        firstPersonCamera.SetActive(false);
        thirdPersonCamera.SetActive(true);
        thirdPersonCameraScript.enabled = true;  // Ativa rotação da câmera em terceira pessoa
    }
}
