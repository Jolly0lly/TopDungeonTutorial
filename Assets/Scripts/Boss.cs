using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{

    //Hitbox
    ContactFilter2D filter;
    private BoxCollider2D hitbox;
    private Collider2D[] hits = new Collider2D[10];

    protected override void Start()
    {
        base.Start();
        xSpeed = 0.2f;
        ySpeed = 0.1f;
        startingPosition = GameObject.Find("SP_Boss").transform.position;

    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
       
    }

}
