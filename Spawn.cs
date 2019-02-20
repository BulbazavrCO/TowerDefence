using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [Header("Место спавна")]
    public Transform SpawnPoint;

    public void CreateEnemy(List<ICell> cells, GameObject go)
    {
        IMove move = Instantiate(go, SpawnPoint.position, Quaternion.identity).GetComponent<IMove>();
        move.Move(cells);        
    }
}

