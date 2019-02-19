using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISound 
{
    void AddSound();

    void Volume(float value, TypeSound type);
}
