using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public Sound[] Sounds;

    private void Awake() {
        foreach (var sound in Sounds){
            sound.AudioSource = gameObject.AddComponent<AudioSource>();
            sound.AudioSource.volume = sound.Volume;
            sound.AudioSource.clip = sound.AudioClip;
            sound.AudioSource.pitch = sound.Pitch;
        }
    }

    public void PlayMusic(string name){
        Sounds.Where(sound => sound.Name == name)?.First().AudioSource.Play();
    }
}
