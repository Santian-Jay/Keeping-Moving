using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToGame : MonoBehaviour
{
    public GameObject pause;


    GameStateControl gameState;
    // Start is called before the first frame update
    void Start()
    {
        gameState = pause.GetComponent<GameStateControl>();

    }

    public void ContinueGame()
    {
        gameState.GameStart();
    }
}
