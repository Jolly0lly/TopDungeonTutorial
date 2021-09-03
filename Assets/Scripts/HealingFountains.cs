using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingFountains : Collidable
{
    public Collider2D fountainCollider;
    [SerializeField] int healAmount;
    [SerializeField] int healDuration;
    protected void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.tag == "Attackable")
        {
            HealingStruct hL = new HealingStruct();
            hL.healAmount = healAmount;
            hL.healDuration = healDuration;
            Debug.Log(coll.name);
            coll.SendMessage("Heal", hL);
        }   
        

            
               
               
         
            
            
        
    }
    


}
    
   

