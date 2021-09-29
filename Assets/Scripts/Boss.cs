using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{

    //Hitbox
    ContactFilter2D filter;
    private BoxCollider2D hitbox;
    private Collider2D[] hits = new Collider2D[10];
    //[SerializeField] private Animator animator;

    //protected override void UpdateMotor(Vector3 input)
    //{
    //    base.UpdateMotor(input);
    //    if (moveDelta != Vector3.zero)
    //        animator.SetBool("Walking", true);
    //    else animator.SetBool("Walking", false);
    //}


}
