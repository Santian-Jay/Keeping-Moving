using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameStateControl : MonoBehaviour
{
    public GameObject pause;

    private Animator ani;

    private bool isPause = false;

    void Start()
    {
        ani = pause.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause)
            {
                GameStart();
            }
            else
            {
                GamePause();
                
            }
        }
    }
    public void GamePause()
    {
        ani.SetBool("IsPush", true);
        SingletonManagement.instance.PauseGame();
        isPause = true;
    }

    public void GameStart()
    {
        ani.SetBool("IsPush", false);
        SingletonManagement.instance.StartGame();
        isPause = false;
    }
}
