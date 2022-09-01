using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSound : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip[] audios;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.volume = SingletonManagement.instance.sound;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AudioPlay(string tag)
    {
        switch(tag)
        {
            case "Copper":
            audioSource.clip = audios[0];
            audioSource.Play();
            break;
            case "Gold":
            audioSource.clip = audios[1];
            audioSource.Play();
            break;
            case "Star":
            audioSource.clip = audios[3];
            audioSource.Play();
            break;
            case "Shield":
            audioSource.clip = audios[2];
            audioSource.Play();
            break;
            case "Shield_Broken":
            audioSource.clip = audios[7];
            audioSource.Play();
            break;
            case "First_Jump":
            audioSource.clip = audios[4];
            audioSource.Play();
            break;
            case "Second_Jump":
            audioSource.clip = audios[5];
            audioSource.Play();
            break;
            case "Fly":
            audioSource.clip = audios[6];
            audioSource.Play();
            break;
            case "Monster_Mushroom":
            audioSource.clip = audios[8];
            audioSource.Play();
            break;
            case "P":
            audioSource.clip = audios[9];
            audioSource.Play();
            break;
        }

    }
}
