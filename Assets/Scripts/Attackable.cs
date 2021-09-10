using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackable: MonoBehaviour, IAttackable
{
    // Public fields

    public int hitpoints;
    public int maxHitpoints;
    public float pushRecoveryDelay = 0.2f;
    public static Attackable attackableInstance;
    

    //Immunity
    protected float immuneTime = 1.0f;
    float lastImmune = 0;


    //Push

    protected Vector3 pushDirection;

    //All attackable can ReceiveDamage, be healed and Die 

    private void Awake()
    {
        attackableInstance = this;
    }

    public void ReceiveDamage(Damage dmg)
    {   
        
        if (Time.time - lastImmune > immuneTime)
        {
            lastImmune = Time.time;
            hitpoints -= dmg.damageAmount;
            pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;

            GameManager.instance.ShowText(dmg.damageAmount.ToString(), 35, Color.red, transform.position , Vector3.up * 25, 0.5f);
                

            if (hitpoints <= 0)
            {
                hitpoints = 0;
                Death();
            }

        }
    }

    public IEnumerator Heal(HealingStruct hL)
    {
        while (hL.healDuration > 0)
        {
           



            if (hitpoints > maxHitpoints || hitpoints == maxHitpoints)
            {
                hitpoints = maxHitpoints;
                GameManager.instance.ShowText("Fully Healed!", 30, Color.green, transform.position, Vector3.up *30, 1.0f);
                yield break;
            }

            else
            {
                hitpoints += hL.healAmount;
                GameManager.instance.ShowText("+" + hL.healAmount.ToString() + " HP!", 30, Color.green, transform.position, Vector3.up*30, 1.0f);

                if (hitpoints > maxHitpoints || hitpoints == maxHitpoints)
                {
                    hitpoints = maxHitpoints;
                    yield return new WaitForSeconds(1);
                    GameManager.instance.ShowText("Fully Healed!", 30, Color.green, transform.position, Vector3.up * 30, 1.0f);
                    yield break;
                }
            }

            yield return new WaitForSeconds(hL.healDelay);
            hL.healDuration--;

        }
    }

    protected virtual void Death()
    {

    }

}
