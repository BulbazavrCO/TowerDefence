using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeCell
{
    road,
    hill,
    tower,
    decor,
    grass
}

public interface ICell 
{
    int X { get; }
    int Z { get; }

    TypeCell Type { get; }

    Transform pos { get; }    

    bool IsCreate();
}
