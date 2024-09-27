using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static SoundManagerScript instance { get; private set; }  // singleton pattern --> which as you can see involves creating a public static variable of the same class
                                                // as this one called instance. Making a variable like this one static ensures that it will be stored in the memory as the only copy 
                                                // so there can be no other sound manager instance while we have this one which is good because the next time when another class wants to reference
                                                // the sound manager we don't need to create a reference for it like we usually do and we can directly type soundmanager.instance and call the method

                                                // get private set --> access this  instance from outside scripts but modify it only from this script
    private AudioSource source;

    private void Awake()
    {
        instance = this;
        source = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip _sound)
    {
        source.PlayOneShot(_sound); // it allows us to play audio clip only once
    }
}
