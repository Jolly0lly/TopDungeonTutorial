using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Collidable
{
    //Logic
    protected bool collected;
    protected Player player;
    

    protected override void OnCollide(Collider2D coll)
    {
        base.OnCollide(coll);
        player = coll.GetComponent<Player>();
        if (player != null)
        {
            OnCollect();
        }
            
            
    }
    protected virtual void OnCollect()
    {
        collected = true;
        Debug.Log("collected");
    }


}
