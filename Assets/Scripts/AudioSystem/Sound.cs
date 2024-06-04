using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Sound
{
    [SerializeField] private AudioClip _clip;
    [SerializeField] private AudioNames _name;

    public AudioNames Name { get { return _name; } }
    public AudioClip Clip { get { return _clip; } }
}
