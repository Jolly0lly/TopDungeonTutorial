using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : Collidable
{
    //Damage
    public int damage = 1;
    public float pushForce = 3;


    protected override void OnCollide(Collider2D coll)
    {
        IAttackable attackable = coll.GetComponent<IAttackable>();
        if (attackable != null && coll.name == "Player")
        {
            //Create a new damage object before sending it to the player
            Damage dmg = new Damage();
            dmg.damageAmount = damage;
            dmg.origin = transform.position;
            dmg.pushForce = pushForce;

            attackable.ReceiveDamage(dmg);
            //
            //coll.SendMessage("ReceiveDamage", dmg);

            
        }
    }
}
