using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour, ICrush
{
    private int x;
    private int z;

    public int X { get => x; }

    public int Z { get => z; }

    [SerializeField] private TypeCell type = TypeCell.grass;

    public TypeCell Type { get => type; }

    public Transform pos { get; private set; }

    void Start()
    {
        pos = GetComponent<Transform>();
        x = (int)pos.position.x;
        z = (int)pos.position.z;
        AddCell();
    }

    public void Crush()
    {
        GameManager.instance.RemoveCell(x, z);
        Destroy(gameObject);
    }

    private void AddCell()
    {       
        GameManager.instance.AddCell(x, z, this);
    }

    public bool IsCreate()
    {
        return false;
    }
}
