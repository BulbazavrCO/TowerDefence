using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeCell
{
    road,
    hill,
    tower,
    decor   
}

public interface ICell 
{
    int X { get; }
    int Z { get; }

    TypeCell Type { get; }

    Transform pos { get; }

    void CreateCell(int x, int z, Transform parrent, TypeCell type);

    bool IsCreate();
}
