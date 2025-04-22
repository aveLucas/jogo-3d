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
        // Pega rotação da câmera TP
        Vector3 tpEulerAngles = thirdPersonCamera.transform.eulerAngles;

        // Aplica na FP
        firstPersonCamera.transform.eulerAngles = tpEulerAngles;

        // Alinha o corpo do player com a rotação horizontal da TP
        player.transform.eulerAngles = new Vector3(0f, tpEulerAngles.y, 0f);

        // Envia rotação vertical da TP para o script da FP (usando rotX direto)
        firstPersonCamera.GetComponent<FirstPersonCamera>().SetRotation(thirdPersonCameraScript.GetRotation());

       
        firstPersonCamera.SetActive(true);
        thirdPersonCamera.SetActive(false);
        thirdPersonCameraScript.enabled = false;  // Desativa rotação livre da câmera de terceira pessoa
    }

    void SwitchToThirdPerson()
    {
        // Pega a rotação atual da câmera FP
        Vector3 fpEulerAngles = firstPersonCamera.transform.eulerAngles;

        // Aplica ao script da câmera TP
        thirdPersonCameraScript.SetRotation(fpEulerAngles);

        // Ativa/desativa câmeras
        firstPersonCamera.SetActive(false);
        thirdPersonCamera.SetActive(true);
        thirdPersonCameraScript.enabled = true;
    }
}
