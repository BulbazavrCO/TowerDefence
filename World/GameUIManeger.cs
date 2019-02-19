using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIManeger : MonoBehaviour
{
    public static GameUIManeger instance { get; private set; }    

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
}
