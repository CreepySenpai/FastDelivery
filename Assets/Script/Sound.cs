using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Sound
{
    public string Name;

    [Range(0.0f, 1.0f)]
    public float Volume;

    [Range(0.0f, 2.0f)]
    public float Pitch;

    public AudioClip AudioClip;

    [HideInInspector]
    public AudioSource AudioSource;

}
