using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeDamage
{
    ice,
    fire,
    earth,
    physic
}

public enum TypeAttak
{
   mele,
   range,
   all
}

[RequireComponent(typeof(AllSounds))]
public abstract class Tower : MonoBehaviour, ICell, ISelected, ICreate
{
    public int X { get; private set; }

    public int Z { get; private set; }

    public Transform pos { get; private set; }

    public TypeCell Type { get; private set; }

    [Header("Материалы объекта")]
    public Renderer render;
    public Material standart;
    public Material Outline;
    public Material CreateMat;
    public Material NonCreateMat;

    protected float damage;
    protected float attakSpeed;
    protected float attakRange;
    protected TypeDamage typeTower;
    protected TypeAttak typeAttak;
    protected AllSounds sound;

    protected bool creation = true;

    private float calculateDamage;
    

    [Header("Ссылка на ScritableObject объекта")]
    public InfoTower infoTower;    

    public void CreateCell(int x, int z, Transform parrent, TypeCell type)
    {
        pos = GetComponent<Transform>();
        X = x;
        Z = z;
        pos.SetParent(parrent);
        Type = type;
    }

    public void Selected()
    {
        render.material = Outline;
        var info = new TowerInfo
        {
            Damage = damage.ToString(),
            AttakRange = attakRange.ToString(),
            AttakSpped = attakSpeed.ToString(),
            Icon = infoTower.icon,
            iconAttak = infoTower.iconAttak,
            iconDamage = infoTower.iconDamage,
            name = infoTower.name,
            discription = infoTower.discription
        };
        GameUIManeger.instance.SelectedTower(info);
    }

    public void Disable()
    {
        render.material = standart;
    }

    public void RacalculateDamage(float value)
    {
        calculateDamage += value;
        damage *= calculateDamage;
    }

    public void Create(Vector3 position, bool isCreate)
    {
        pos.position = position;
        if (isCreate)
            render.material = CreateMat;
        else
            render.material = NonCreateMat;
    }

    public void Spawn(Vector3 pos)
    {
        damage = infoTower.damage;
        attakSpeed = infoTower.attakSpeed;
        attakRange = infoTower.attakRange;
        typeTower = infoTower.typeTower;
        typeAttak = infoTower.typeAttak;
        render.material = standart;
        sound = GetComponent<AllSounds>();
        sound.AddSound();
        creation = false;
    }

    public bool IsCreate()
    {
        return false;
    }

    #region Abstract methods

    protected abstract void Attak();

    public abstract void DeleteTower();

    public abstract void BuildTower();  

    #endregion
}

public struct TowerInfo
{
    public string Damage;
    public string AttakSpped;
    public string AttakRange;

    public Sprite Icon;
    public Sprite iconAttak;
    public Sprite iconDamage;

    public string name;   
    public string discription;

}
