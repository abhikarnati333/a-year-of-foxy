using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{

    public AudioSource AudioSource;
    public float musicVolume;


    // MusicPlay
    void Start()
    {
        AudioSource.Play();
    }

    //Volume
    void Update()
    {

        AudioSource.volume = musicVolume;
   
    }

    //VolumeSlider
    public void updateVolume( float volume)

    {
        musicVolume = volume;
    }

}


