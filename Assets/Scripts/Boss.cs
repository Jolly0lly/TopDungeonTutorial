using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{

    //Hitbox
    ContactFilter2D filter;
    private BoxCollider2D hitbox;
    private Collider2D[] hits = new Collider2D[10];


}
