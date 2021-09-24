using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackable
{ 
    void ReceiveDamage(Damage dmg);

    IEnumerator Heal(HealingStruct hL);

    
}
