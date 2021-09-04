using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : UnmovedMover

{
    private SpriteRenderer spriteRenderer;
    public static Player playerInstance;
    public RectTransform hpBar;


    private void Awake()
    {
        if (Player.playerInstance != null)
        {
            Destroy(gameObject);
            return;
        }

        playerInstance = this;
    }


    protected override void Start()
    {
        base.Start();
        hitpoints = maxHitpoints = 10;
        spriteRenderer = GetComponent<SpriteRenderer>();
        DontDestroyOnLoad(gameObject);
        
    }
    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        UpdateMotor(new Vector3(x, y, 0));
    }

    public void SwapSprite(int currentArmor)
    {
        spriteRenderer.sprite = GameManager.instance.armorSprites[currentArmor];
    }

    public void OnLevelUp()
    {

        maxHitpoints += 10;
        hitpoints = maxHitpoints;
        GameManager.instance.learningPoints += 10;
        GameManager.instance.ShowText("Level Up!!!", 40, Color.magenta, transform.position, Vector3.up * 30, 2);
    }

    public void SetLevel(int level)
    {
        for (int i = 0; i < level; i++)
        {
            if (i == 0)
                return;
            OnLevelUp();
        }
    }

    private void Update()
    {
        float hpRatio;

        hpRatio = (float)hitpoints / (float)maxHitpoints;

        hpBar.localScale = new Vector3(hpRatio, 1, 1);
        

    }

   

   

}
