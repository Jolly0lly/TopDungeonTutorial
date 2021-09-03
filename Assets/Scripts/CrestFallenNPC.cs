using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrestFallenNPC : Collidable
{
    public string message;
    float cooldown = 5;
    float lastShout;

    protected override void OnCollide(Collider2D coll)
    {
        if(Time.time - lastShout> cooldown)
        {
            lastShout = Time.time;
            GameManager.instance.ShowText(message, 40, Color.white, transform.position, Vector3.zero, 4);
        }
    }
        
}
