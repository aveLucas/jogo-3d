using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject firstPersonCamera;  // C�mera de primeira pessoa
    public GameObject thirdPersonCamera;  // C�mera de terceira pessoa
    public Transform player;  // Refer�ncia ao jogador
    public ThirdPersonCamera thirdPersonCameraScript;  // Script da c�mera de terceira pessoa

    private bool isFirstPerson = true;

    void Start()
    {
        SwitchToFirstPerson();
    }

    void Update()
    {
        if (GameManager.isPaused != true && Input.GetKeyDown(KeyCode.F5)) // Tecla para trocar a c�mera
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
        thirdPersonCameraScript.enabled = false;  // Desativa rota��o livre da c�mera de terceira pessoa
    }

    void SwitchToThirdPerson()
    {
        firstPersonCamera.SetActive(false);
        thirdPersonCamera.SetActive(true);
        thirdPersonCameraScript.enabled = true;  // Ativa rota��o da c�mera em terceira pessoa
    }
}
