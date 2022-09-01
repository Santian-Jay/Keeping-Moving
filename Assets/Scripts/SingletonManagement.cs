using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonManagement : MonoBehaviour
{
    public static SingletonManagement instance;

    public float startTime = 0f;

    public float repeateRate = 1f;

    private int time = 0;

    private float speedIncreaseTimeDelay = 120f;

    public float speedGive = 3;

    private float speedIncreaseRate = 1.1f;

    public GameObject block;

    public GameObject background;

    public GameObject newBlock;

    public GameObject score;

    public float sound = 0.5f;

    public float music = 0.5f;

    public float highscoreOutPut;

    public float defaultScore = 0f;


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        InvokeRepeating("ActiveObject", startTime, repeateRate);
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }

        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ActiveObject()
    {
        time++;
        if ((time % speedIncreaseTimeDelay) == 0)
        {
            speedGive = speedGive * speedIncreaseRate;
        }

    }


    public void PauseGame()
    {
        if (newBlock != null)
        {
            newBlock.GetComponent<BlockMove>().speed = 0;
        }

        if (block != null)
        {
            block.GetComponent<BlockMove>().speed = 0;
            
        }
        score.GetComponent<Score>().GamePause();
        CancelInvoke();
        background.GetComponent<BackgroungMove>().GamePause();

    }

    public void StartGame()
    {
        if (newBlock != null)
        {
            newBlock.GetComponent<BlockMove>().speed = speedGive;
        }

        if (block != null)
        {
            block.GetComponent<BlockMove>().speed = speedGive;
            
        }
        score.GetComponent<Score>().GameStart();
        InvokeRepeating("ActiveObject", startTime, repeateRate);
        background.GetComponent<BackgroungMove>().GameStart();
    }

    public void RemoveBlock()
    {
        block = newBlock;
    }
}
