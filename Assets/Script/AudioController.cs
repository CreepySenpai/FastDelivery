using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private static AudioController s_instance = null;

    public static AudioController GetInstance(){
        if (s_instance == null)
        {
            s_instance = GameObject.FindObjectOfType<AudioController>();
        }
        return s_instance;
    }

    public Sound[] Sounds;

    private void Awake() {
        foreach (var sound in Sounds){
            sound.AudioSource = gameObject.AddComponent<AudioSource>();
            sound.AudioSource.volume = sound.Volume;
            sound.AudioSource.clip = sound.AudioClip;
            sound.AudioSource.pitch = sound.Pitch;
            sound.AudioSource.loop = sound.IsLoop;
        }
    }

    public void PlayMusic(string name){
        Sounds.Where(sound => sound.Name == name)?.First().AudioSource.Play();
    }

    public void StopMusic(string name){
        Sounds.Where(sound => sound.Name == name)?.First().AudioSource.Stop();
    }

    public void PauseMusic(string name){
        Sounds.Where(sound => sound.Name == name)?.First().AudioSource.Pause();
    }

    public void ContinueMusic(string name){
        Sounds.Where(sound => sound.Name == name)?.First().AudioSource.UnPause();
    }
}
