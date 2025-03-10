using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    
    public Transform pauseMenu;

    // Start is called before the first frame update
    void Awake()
    {
        
        pauseMenu.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Continue()
    {
        pauseMenu.gameObject.SetActive(false);
        GameManager.Instance.TogglePause(false); // ✅ Agora o jogo despausa corretamente
        Debug.Log("Jogo despausado");
    }


    public void Configuration()
    {
        
    }
}
