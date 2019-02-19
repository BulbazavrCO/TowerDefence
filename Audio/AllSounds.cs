using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeSound
{
    sound,
    music
}

[RequireComponent(typeof(AudioSource))]
public class AllSounds : MonoBehaviour, ISound
{
    public TypeSound type;
    AudioSource source;

    public void AddSound()
    {
        GameUIManeger.instance.AddSound(this);
        source = GetComponent<AudioSource>();
    }

    public void Volume(float value, TypeSound type)
    {
        if (this.type == type)
            source.volume = value;
    }
}
