using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public Transform pauseM;
    public static bool isPaused { get;  set; }
    public static event Action<bool> OnPauseStateChanged;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause(!isPaused);
        }
    }

    public void TogglePause(bool pauseState)
    {
        isPaused = pauseState;
        Time.timeScale = isPaused ? 0 : 1;
        pauseM.gameObject.SetActive(isPaused);
        OnPauseStateChanged?.Invoke(isPaused); // ✅ Agora o evento é invocado corretamente dentro da classe
        Cursor.lockState = isPaused ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = isPaused;
    }

   /* public void TogglePause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            Time.timeScale = isPaused ? 0 : 1;
            OnPauseStateChanged?.Invoke(isPaused);
            if (isPaused)
            {
                pauseM.gameObject.SetActive(true);

            }
            else
            {
                pauseM.gameObject.SetActive(false);

            }
        }
    }*/
}
