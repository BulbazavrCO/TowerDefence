using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeMove
{
    standart,
    air
}

public abstract class Enemy : MonoBehaviour, IHealth, IMove, ISelected, ISpawn
{
    public EnemyInfo infoEnemy;

    public Renderer render;
    public Material standart;
    public Material Outline;

    protected float hp;
    protected float maxHP;
    protected float moveSpeed;
    protected float armor;

    private float coefMoveSpeed;

    protected TypeDamage resist;

    protected TypeMove typeMove;

    protected List<ICell> MovePoints;
    
    public void AddHealth()
    {
        GameManager.instance.AddHealth(this);
    }

    public void Damage(float value, TypeDamage type)
    {       
        float damage = 0;
        if (type == TypeDamage.physic)
            damage = value * (1 - 0.06f * armor / (1 + (0.06f * Mathf.Abs(armor)))); 
        else
        damage = resist == type ? value / 2 : value;

        if (hp - damage <= 0)
        {
            hp = 0;
            Dead();
        }
        else
        {
            hp -= damage;
        }
    }

    public void Dead()
    {
        GameManager.instance.RemoveHealth(this);
        Destroy(gameObject);
    }

    public IMove GetMove() => this;

    public void Heal(float value)
    {
        if (hp + value >= maxHP)
        {
            hp = maxHP;
        }
        else
        {
            hp += value;
        }
    }

    public bool IsAttak(TypeAttak type)
    {
        if (type == TypeAttak.all)
            return true;

        if (type == TypeAttak.mele && typeMove == TypeMove.standart)
            return true;

        if (type == TypeAttak.range && typeMove == TypeMove.air)
            return true;

        return false;
    }

    public void Move(List<ICell> MovePoints)
    {
        this.MovePoints = MovePoints;
    }

    public void RecalculateMove(float value)
    {
        coefMoveSpeed += value;
        moveSpeed *= coefMoveSpeed;
    }

    public void Selected()
    {
        render.material = Outline;
        var info = new InfoEnemy
        {
            HP = hp,
            MaxHP = maxHP,
            Armor = armor.ToString(),
            icon = infoEnemy.icon,
            iconResist = infoEnemy.iconResist,
            name = infoEnemy.name,
            discription = infoEnemy.discription
        };
        GameUIManeger.instance.SelectedEnemy(info);
    }

    public void Disable()
    {
        render.material = standart;
    }

    public virtual void Spawn(Vector3 pos)
    {
        AddHealth();
        maxHP = infoEnemy.MaxHP;
        hp = maxHP;
        moveSpeed = infoEnemy.MoveSpeed;
        armor = infoEnemy.Armor;
        resist = infoEnemy.resist;
        AddHealth();
    }
}

public struct InfoEnemy
{
    public float HP;
    public float MaxHP;
    public string MoveSpeed;
    public string Armor;


    public Sprite icon;
    public Sprite iconResist;

    public string name;
    public string discription;
}
