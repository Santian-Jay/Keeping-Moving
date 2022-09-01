using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBlockManagement : MonoBehaviour
{

    public GameObject[] levelPrefabsToChooseFrom;

    public float radius = 1;

    //public GameObject player;

    private Score scoreScript;

    public GameObject trap;

    public GameObject square;

    private int limit = 20;

    private int time = 0;

    public float startTime = 0f;

    public float repeateRate = 1f;

    // Start is called before the first frame update
    void Start()
    {
        NewSpawner();
        trap.SetActive(false);
        InvokeRepeating("ActiveObject", startTime, repeateRate);
    }



    void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.gameObject.tag == "Block")
        {
            SingletonManagement.instance.RemoveBlock();
            NewSpawner();
        }
    }

    public void NewSpawner()
    {
        var spawnPosition = (Vector2)transform.position + Random.insideUnitCircle * radius;


        int random = Random.Range(0,8);
        GameObject levelBlockPrefab = levelPrefabsToChooseFrom[random];

        var newLevel = Instantiate(levelBlockPrefab, spawnPosition, Quaternion.identity);
        SingletonManagement.instance.newBlock = newLevel;
    }

    void ActiveObject()
    {
        time++;
        if ((time%limit) == 0)
        {
            trap.SetActive(true);
            square.SetActive(false);
        }
    }
}
