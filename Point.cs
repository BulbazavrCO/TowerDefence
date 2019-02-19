using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour, ICell
{
    public int X { get; private set; }

    public int Z { get; private set; }

    public Transform pos { get; private set; }

    public TypeCell Type { get; private set; }

    public void CreateCell(int x, int z, Transform parrent, TypeCell type)
    {
        pos = GetComponent<Transform>();
        X = x;
        Z = z;
        pos.SetParent(parrent);
        Type = type;
    }

    public bool IsCreate()
    {
        if (Type == TypeCell.hill)
            return true;
        return false;
    }
}
