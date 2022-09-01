using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicValueSetting : MonoBehaviour
{

    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.volume = SingletonManagement.instance.music;
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = SingletonManagement.instance.music;
    }
}
