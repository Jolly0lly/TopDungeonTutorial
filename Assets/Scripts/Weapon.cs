using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable
{


    //Upgrade

    public int WeaponLevel => weaponLevel;
    public int weaponLevel;
    private SpriteRenderer spriteRenderer;

    //Swing

    private float cooldown = 0.5f;
    private float lastSwing;
    private Animator anim;

    protected override void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        weaponLevel = 0;
    }

    protected override void OnCollide(Collider2D coll)
    {
        IAttackable attackable = coll.GetComponent<IAttackable>();
        Player player = coll.GetComponent<Player>();
        if (attackable != null)
        {
            if (player != null)
                return;
            // Create a new damage object, then send it to the attackable object hit

            Damage dmg = new Damage();
            dmg.damageAmount = weaponLevel + 1;
            dmg.origin = transform.position;
            dmg.pushForce = 2.0f + (float) weaponLevel/5;

            attackable.ReceiveDamage(dmg);
        }
        
    }

    protected override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(Time.time - lastSwing > cooldown)
            {
                lastSwing = Time.time;
                Swing();
            }
        }

        if (weaponLevel > GameManager.instance.weaponPrices.Count)
            weaponLevel = GameManager.instance.weaponPrices.Count; //weird behaviour of save/loadstate
    }


    private void Swing()
    {
        anim.SetTrigger("Swing");
        
    }

    public void UpgradeWeapon()
    {
        weaponLevel++;
        spriteRenderer.sprite = GameManager.instance.weaponSprites[weaponLevel];
    }
}
        



        

        
        

       
