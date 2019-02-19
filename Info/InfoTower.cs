using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTower", menuName = "Tower")]
public class InfoTower : ScriptableObject
{
    public float damage;
    public float attakSpeed;
    public float attakRange;
    public TypeDamage typeTower;
    public TypeAttak typeAttak;


    public Sprite icon;
    public Sprite iconAttak;
    public Sprite iconDamage;

    public new string name;
    [TextArea]
    public string discription;
}
