using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Размеры карты")]
    [SerializeField] private int xSize = 15;
    [SerializeField] private int zSize = 15;
    private int health = 30;

    public int XSize { get => xSize; }
    public int ZSize { get => zSize; }

    public int coefSize;

    [Header("Ссылки на объекты")]
    public GameObject Point;    

    public static GameManager instance { get; private set; }

    public ControlWaves control;

    private List<IHealth> allHealth = new List<IHealth>();

    private ISelected selected;

    private ICreate tower;

    private bool create;

    public ICell[,] Cells { get; private set; }

    private int selectionX;
    private int selectionZ;

    private void Start()
    {
        instance = this;
        Cells = new ICell[xSize, zSize];
    }

    private void Update()
    {
        UpdateSelection();

        if (create)
        {
            if (tower != null)
            {
                tower.Create(CreatePosition(), IsCreate());
                if (Input.GetMouseButtonDown(0) && IsCreate())
                {
                    create = false;
                    tower.Spawn(CreatePosition());
                }

            }
        }
    }

    public void Create(GameObject go)
    {
        tower = Instantiate(go).GetComponent<ICreate>();
        tower.Create();
        create = true;
    }

    private void UpdateSelection()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Plane")
            {
                selectionX = (int)hit.point.x;
                selectionZ = (int)hit.point.z;               
            }
        }
    }

    private Vector3 CreatePosition()
    {
        var c = Cells[selectionX, selectionZ];

        if (c != null)
            return c.pos.position + Vector3.up;
        else
            return new Vector3(selectionX + 0.5f, 1.0f, selectionZ + 0.5f);
    }

    private bool IsCreate()
    {
        var c = Cells[selectionX, selectionZ];
        if (c == null || (c != null && c.Type == TypeCell.hill))
        {
            return true;
        }
        return false;
    }

    public void AddCell(int x, int z, ICell cell)
    {
        if (x > -1 && x < xSize && z > -1 && z < zSize)
            Cells[x, z] = cell;
    }

    public void RemoveCell(int x, int z)
    {
        if (x > -1 && x < xSize && z > -1 && z < zSize)
            Cells[x, z] = null;
    }

    public void AddMovePoints(ICell cell)
    {
        control.AddMovePoints(cell);
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
