using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class teste : MonoBehaviour
{
    public GameObject coisa;
    public Transform firePoint;
    public float speed, duration;

    // Start is called before the first frame update
    void Start()
    {
        firePoint = GameObject.Find("FirePoint").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            tiro();
        }
        
    }

    void tiro()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
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
            shootDirection = Camera.main.transform.forward;
        }

        GameObject coisa1 = Instantiate(coisa, firePoint.position, Quaternion.identity);

        coisa1.GetComponent<Rigidbody>().AddForce(shootDirection.normalized * speed, ForceMode.Impulse);

        
    }
}
