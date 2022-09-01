using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public Text scoreText;
    public int score = 0;

    public int tScore = 0;

    public int startTime = 1;


    public float repeateRate = 1f;

    int newHighScore = 0;

    public int highScore = 0;
    public string highScorer = "";


    //private LevelBlockManagement levelBlockScript;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("TimeScore", startTime, repeateRate);
        RefreshText();
        SingletonManagement.instance.score = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void IncreaseScore(string tag)
    {
        switch (tag)
        {
            case "Copper":
                tScore += 1;
                break;
            case "Gold":
                tScore += 2;
                break;
            case "Star":
                tScore += 3;
                break;
            case "MushRoom":
                tScore += 5;
                break;
        }
        RefreshText();

    }

    public void RefreshText()
    {
        scoreText.text = tScore.ToString();
        
    }

    public void TimeScore()
    {
        tScore++;
        SingletonManagement.instance.highscoreOutPut = tScore;
        RefreshText();
    }

    public void GamePause()
    {
        CancelInvoke();
    }

    public void GameStart()
    {
        InvokeRepeating("TimeScore", startTime, repeateRate);
    }


    public void OnApplicationQuit()
    {
        PlayerPrefs.SetString("HighScorer", highScorer);
        PlayerPrefs.SetInt("HighScore", highScore);

        PlayerPrefs.Save();
    }

    public void AddScore(string name)
    {
        highScorer = name;
        highScore = newHighScore;
    }

    public bool IsHighScore(int newScore)
    {
        if (newScore > score)
        {
            newHighScore = newScore;
            return true;
        }
        return false;
    }
}
