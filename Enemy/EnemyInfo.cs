using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemy", menuName = "Enemy")]
public class EnemyInfo : ScriptableObject
{

    public float MaxHP;
    public float MoveSpeed;
    public float Armor;

    public TypeDamage resist;

    public Sprite icon;
    public Sprite iconResist;

    public new string name;
    [TextArea]
    public string discription;



}
