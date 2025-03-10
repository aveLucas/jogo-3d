using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEffect : MonoBehaviour
{
    
    [SerializeField] private float maxDuration = 5f;

    private void Update()
    {
            StartCoroutine("Duration");
       
    }

    IEnumerator Duration()
    {
        yield return new WaitForSeconds( maxDuration );
        Destroy(gameObject);
    }
}
