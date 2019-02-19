using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIManeger : MonoBehaviour
{
    public static GameUIManeger instance { get; private set; }

    public List<ISound> AllSound = new List<ISound>();

    private void Start()
    {
        instance = this;
    }

    public void SelectedTower(TowerInfo info)
    {

    }

    public void SelectedEnemy(InfoEnemy info)
    {

    }

    public void SetMusicValue(float value)
    {
        foreach(var s in AllSound)
        {
            s.Volume(value, TypeSound.music);
        }
    }

    public void SetSoundValue(float value)
    {
        foreach (var s in AllSound)
        {
            s.Volume(value, TypeSound.sound);
        }
    }

    public void AddSound(ISound sound)
    {
        AllSound.Add(sound);
    }


}
