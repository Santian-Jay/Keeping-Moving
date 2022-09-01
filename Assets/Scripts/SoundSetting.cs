using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSetting : MonoBehaviour
{
    // Start is called before the first frame update
    Slider slider;

    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
        slider.value = SingletonManagement.instance.music;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnValueChanged(float value)
    {
        SingletonManagement.instance.sound = value;
    }
}
