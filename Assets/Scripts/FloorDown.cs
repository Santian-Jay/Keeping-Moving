using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorDown : MonoBehaviour
{

    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {

            StartCoroutine(Change());
            StartCoroutine(DestoryFloor());
        }
    
    }

    IEnumerator DestoryFloor()
    {
        yield return new WaitForSeconds(3f);
        Destroy(this.gameObject);
    }

    IEnumerator Change()
    {
        yield return new WaitForSeconds(0.5f);
        this.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

    }
}
