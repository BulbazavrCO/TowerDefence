using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlWaves : MonoBehaviour
{
    [Header("Волны врагов")]
    public List<Waves> wawes = new List<Waves>();    

    public float TimeWawes = 10.0f;
    public float TimeUnits = 3.0f;

    public Spawn spawn;

    int numberWave = 0;
    int numberUnit = 0;
    private List<ICell> MovePoints = new List<ICell>();

    private void Start()
    {
        if (IsWave())
        StartCoroutine(StartSpawn(TimeWawes));
    }

    public void CreateEnemy(List<ICell> cells)
    {        
        numberUnit++;
        if (numberUnit >= wawes[numberWave].prefabs.Length)
        {
            numberUnit = 0;
            numberWave++;
        }
    }

    public void AddMovePoints(ICell cell)
    {
        MovePoints.Add(cell);
    }

    public bool IsWave()
    {
        
        if (numberWave >= wawes.Count)
            return false;
        return true;
    }

    private IEnumerator StartSpawn(float time)
    {
        yield return new WaitForSeconds(time);
        float tm = TimeUnits;
        spawn.CreateEnemy(MovePoints, wawes[numberWave].prefabs[numberUnit]);
        numberUnit++;
        if (numberUnit >= wawes[numberWave].prefabs.Length)
        {
            tm = TimeWawes;
            numberUnit = 0;
            numberWave++;
        }
        if (IsWave())
            StartCoroutine(StartSpawn(tm));
    }
  
}

[System.Serializable]
public class Waves
{
    public string name;   

    public GameObject[] prefabs;
}
