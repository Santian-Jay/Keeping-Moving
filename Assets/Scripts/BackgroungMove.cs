using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroungMove : MonoBehaviour
{

    Transform background;

    public Material materialPrefab;
    SpriteRenderer sr;
    
    Transform rTransform;
    public float speed = 0.5f;

    private float currentSpeed;

    private float time_f = 0f;
    private float time_i = 0f;

    private float speedIncreaseRate = 1.1f;

    public float startTime = 2f;

    public float repeateRate = 10f;



    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.material = new Material(materialPrefab);
        SingletonManagement.instance.background = this.gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time_f = Time.time;
        time_i = Mathf.FloorToInt(time_f);

        float move = sr.material.GetTextureOffset("_MainTex").x + (speed * Time.deltaTime);
        Vector2 offset = new Vector2(move, 0);
        sr.material.SetTextureOffset("_MainTex", offset);


    }

    void IncreaseSpeed()
    {
        speed = speed * speedIncreaseRate;
    }


    public void GamePause()
    {
        currentSpeed = speed;
        speed = 0;

    }

    public void GameStart()
    {
        speed = currentSpeed;
    }
}
