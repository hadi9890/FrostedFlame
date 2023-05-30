
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public AudioMixer masterVolume;
    [SerializeField] GameObject toggleObj;
    Toggle toggle;

    void Start()
    {
        toggle = toggleObj.GetComponent<Toggle>();
    }

    // Update is called once per frame
    void Update()
    {
        clickbutton();
    }

    public void setVolume(float volume)
    {

        masterVolume.SetFloat("Volume", volume);
    }

    public void clickbutton()
    {

        if (toggle.isOn)
        {
            AudioListener.volume = 1;
        }
        else
        {
            AudioListener.volume = 0;
        }


    }
}
