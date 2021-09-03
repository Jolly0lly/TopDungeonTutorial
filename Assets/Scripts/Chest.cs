using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable
{
    
    public Sprite emptyChest;
    public int friesInChest = 10;
    private bool spacePressed;
    protected override void OnCollect()
    {
        if (!collected)
        {
            spacePressed = Input.GetKeyDown(KeyCode.Space);
            if (spacePressed == true)
            {
                
                collected = true;
                GetComponent<SpriteRenderer>().sprite = emptyChest;
                GameManager.instance.ShowText("+" + friesInChest + " fries", 25, Color.yellow, transform.position, Vector3.up * 25, 1.5f);
                GameManager.instance.fries += friesInChest;
                
            }
            
        }

    }
    



}
