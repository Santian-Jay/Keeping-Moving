using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMove : MonoBehaviour
{
    private Transform blockTransform;

    public float speed = 4f;


    // Start is called before the first frame update
    void Start()
    {
        blockTransform = transform;
        speed = SingletonManagement.instance.speedGive;
        SingletonManagement.instance.newBlock = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(-300f, 0f, 0f), speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.gameObject.tag == "DestoryPoint")
        {
            
            StartCoroutine(DestroyBlock());
        }
    }

    IEnumerator DestroyBlock()
    {
        yield return new WaitForSeconds(15f);
        Destroy(this.gameObject);
    }
}
