using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMove : MonoBehaviour
{

    private Transform groundTransform;
    public Transform startPosition;
    public Transform endPosition;
    public float speed = 0.01f;

    public float offSet = 0.1f;

    public float startTime = 1f;

    public float repeateRate = 100f;

    private float speedIncreaseRate = 1.05f;

    // Start is called before the first frame update
    void Start()
    {
        groundTransform = transform;
        InvokeRepeating("IncreaseSpeed", startTime, repeateRate);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (groundTransform.position.x > endPosition.position.x)
        {
            groundTransform.position -= new Vector3(speed, 0, 0);  //move
        }
        else  //get end position
        {
            BackToStart();
        }
    }


//back to start position
    void BackToStart()
    {
        float xPositionOffSet = Random.Range(1, 5) * offSet;  //random horizontal offset
        float yPositionOffSet = Random.Range(1, 5) * offSet;  //random height offset
        groundTransform.position = startPosition.position + new Vector3(xPositionOffSet, yPositionOffSet, 0);
    }

    void IncreaseSpeed()
    {
        speed = speed * speedIncreaseRate;
    }
}
