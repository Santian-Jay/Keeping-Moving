using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetHighScore : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        GetComponent<Text>().text = SingletonManagement.instance.highscoreOutPut.ToString();
    }
}
