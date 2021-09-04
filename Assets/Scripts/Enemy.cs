using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : UnmovedMover
{


    // Experience
    public int xpValue;

    //Logic
    public float triggerLength = 1;
    public float chaseLength = 5;
    private bool chasing;
    private bool collidingWithPlayer;
    protected Transform playerTransform;
    protected Vector3 startingPosition;
    


    //Hitbox
    ContactFilter2D filter;
    private BoxCollider2D hitbox;
    private Collider2D[] hits = new Collider2D[10];


    //Healing logic
    protected GameObject[] healingFountains;
    protected float[] distance = new float[20];
    
    

    protected override void Start()
    {
        base.Start();
        playerTransform = GameManager.instance.player.transform;
        startingPosition = GameObject.Find("SP_0").transform.position;
        hitbox = transform.GetChild(0).GetComponent<BoxCollider2D>();
        xSpeed = 0.5f;
        ySpeed = 0.4f;
        healingFountains = GameObject.FindGameObjectsWithTag("HealingFountains");
    }


    protected override void UpdateMotor(Vector3 input)
    {
        base.UpdateMotor(input);
        if (moveDelta.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (moveDelta.x < 0)
        {
            transform.localScale = Vector3.one;
        }

        /*if (pushDirection.x < 0.1f)
            pushDirection.x = 0;
        if (pushDirection.y < 0.01f)
            pushDirection.y = 0;
        if (pushDirection.z < 0.1f)
            pushDirection.z = 0;*/
    }



    protected virtual void FixedUpdate()
    {
        //Checking if enmemy collides with player

        collidingWithPlayer = false;

        boxCollider.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
                continue;

            if (hits[i].tag == "Attackable" && hits[i].name == "Player")
            {
                collidingWithPlayer = true;
            }

            hits[i] = null;
        }

        //Checking of player is in range

        var distance = Vector3.Distance(playerTransform.position, transform.position);

        if ((float)hitpoints < (float)maxHitpoints / 2 && healingFountains.Length != 0 && healingFountains != null)
            ReplenishHealth();

        else if (distance < triggerLength && distance < chaseLength)
        {
            if (Vector3.Distance(playerTransform.position, transform.position) < chaseLength)
            {
                if (collidingWithPlayer == false)
                    UpdateMotor((playerTransform.position - transform.position).normalized);
                else
                    UpdateMotor(Vector3.zero);
            }
        }
        else
        {
            UpdateMotor(startingPosition - transform.position);
        }
        



        UpdateMotor(Vector3.zero);

    }

       protected override void Death()
    {
        Destroy(gameObject);
        GameManager.instance.GrantExp(xpValue);
        GameManager.instance.ShowText("+" + xpValue + " xp", 40, Color.magenta, transform.position, Vector3.up * 40, 1.0f);
    }


    protected virtual void ReplenishHealth()
    {
        float minDistance = float.MaxValue;
        int minDistanceFountain = 0;
        for (int i = 0; i < healingFountains.Length; i++)
        {
            
            distance[i] = Vector3.Distance(healingFountains[i].transform.position, transform.position);
            
            if(distance[i] < minDistance)
            {
                minDistance = distance[i];
                minDistanceFountain = i;
            }
        }
       
        UpdateMotor(healingFountains[minDistanceFountain].transform.position - transform.position);
        
    }


}

