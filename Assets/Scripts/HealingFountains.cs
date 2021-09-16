using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingFountains : Collidable
{
    [SerializeField] private Collider2D fountainCollider;
    [SerializeField] private int healAmount;
    [SerializeField] private float healDuration;
    [SerializeField] private float healDelay;
    protected void OnTriggerEnter2D(Collider2D coll)
    {
        IAttackable attackable = coll.GetComponent<IAttackable>();
        if (attackable != null)
        {
            HealingStruct hL = new HealingStruct();
            hL.healAmount = healAmount;
            hL.healDuration = healDuration;
            hL.healDelay = healDelay;
            Debug.Log(coll.name);
            StartCoroutine(attackable.Heal(hL));
        }   
    }
}
        

            
               
               
         
            
            
        
    


    
   

