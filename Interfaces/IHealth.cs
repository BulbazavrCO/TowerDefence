using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealth
{
    void Damage(float value, TypeDamage type);

    void Heal(float value);

    IMove GetMove();

    void AddHealth();    

    void Dead();

    bool IsAttak(TypeAttak type);
    
}
    
