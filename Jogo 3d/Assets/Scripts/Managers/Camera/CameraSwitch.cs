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
        // Pega rota��o da c�mera TP
        Vector3 tpEulerAngles = thirdPersonCamera.transform.eulerAngles;

        // Aplica na FP
        firstPersonCamera.transform.eulerAngles = tpEulerAngles;

        // Alinha o corpo do player com a rota��o horizontal da TP
        player.transform.eulerAngles = new Vector3(0f, tpEulerAngles.y, 0f);

        // Envia rota��o vertical da TP para o script da FP (usando rotX direto)
        firstPersonCamera.GetComponent<FirstPersonCamera>().SetRotation(thirdPersonCameraScript.GetRotation());

       
        firstPersonCamera.SetActive(true);
        thirdPersonCamera.SetActive(false);
        thirdPersonCameraScript.enabled = false;  // Desativa rota��o livre da c�mera de terceira pessoa
    }

    void SwitchToThirdPerson()
    {
        // Pega a rota��o atual da c�mera FP
        Vector3 fpEulerAngles = firstPersonCamera.transform.eulerAngles;

        // Aplica ao script da c�mera TP
        thirdPersonCameraScript.SetRotation(fpEulerAngles);

        // Ativa/desativa c�meras
        firstPersonCamera.SetActive(false);
        thirdPersonCamera.SetActive(true);
        thirdPersonCameraScript.enabled = true;
    }
}
