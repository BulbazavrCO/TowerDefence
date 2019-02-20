using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICreate : ISpawn
{
    void Create();

    void Create(Vector3 position, bool isCreate);
}
