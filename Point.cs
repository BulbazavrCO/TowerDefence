﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour, ICell
{
    private int x;
    private int z;

    public int X { get => x; }

    public int Z { get => z; }

    public Transform pos { get; private set; }

    [SerializeField] private TypeCell type = TypeCell.road;

    public TypeCell Type { get => type; }


    void Start()
    {
        pos = GetComponent<Transform>();
        x = (int)pos.position.x;
        z = (int)pos.position.z;
        AddCell();
    }
   

    private void AddCell()
    {
        GameManager.instance.AddCell(x, z, this);
    }


    public bool IsCreate()
    {
        if (Type == TypeCell.hill)
            return true;
        return false;
    }
}
