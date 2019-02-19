using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMove 
{
    void Move(List<ICell> MovePoints);

    void RecalculateMove(float value);
}
