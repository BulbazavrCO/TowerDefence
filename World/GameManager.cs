using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Размеры карты")]
    public int xSize;
    public int zSize;
    public int coefSize;    

    [Header("Ссылки на объекты")]
    public MapGeneration map;
    public GameObject Point;

    public static GameManager instance { get; private set; }

    private List<ICell> MovePoints = new List<ICell>();

    private List<IHealth> allHealth = new List<IHealth>();

    private ISelected selected;

    public ICell[,] Cells { get; private set; }

    private void Start()
    {
        instance = this;
        Cells = new ICell[xSize, zSize];
        CreateRoad();
        CreateHills();
        map.CreateMap(xSize, zSize, coefSize);
    }

    void CreateRoad()
    {
        for(int x = 0; x < zSize; x++)
        {
            ICell cell = Instantiate(Point, new Vector3(x*coefSize + coefSize / 2, -0.4f, zSize/2*coefSize + coefSize / 2), Quaternion.identity).GetComponent<ICell>();
            cell.CreateCell(x, zSize/2, transform, TypeCell.road);
            Cells[x, zSize/2] = cell;
            MovePoints.Add(cell);
        }
    }

    void CreateHills()
    {
        ICell cell = Instantiate(Point, new Vector3(3 * coefSize + coefSize/2, 0.8f, 3 * coefSize + coefSize / 2), Quaternion.identity).GetComponent<ICell>();
        cell.CreateCell(3, 3, transform, TypeCell.hill);
        Cells[3, 3] = cell;        
    }

    public void AddHealth(IHealth health)
    {
        allHealth.Add(health);
    }

    public void RemoveHealth(IHealth health)
    {
        allHealth.Remove(health);
    }
}
