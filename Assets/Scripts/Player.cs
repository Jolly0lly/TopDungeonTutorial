using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : UnmovedMover

{
    public ArmourItem CurrentArmour => currentArmour;
    private SpriteRenderer spriteRenderer;
    public static Player playerInstance;
    [SerializeField] private RectTransform hpBar;
    private ArmourItem currentArmour;
    [SerializeField] private Sprite defaultPlayerSprite;


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
        hitpoints = maxHitpoints;
        spriteRenderer = GetComponent<SpriteRenderer>();
        DontDestroyOnLoad(gameObject);
        
    }
    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        UpdateMotor(new Vector3(x, y, 0));
    }

    public void SwapSprite(Item item)
    {
        if (item != null)
        {
            if (item.Type != 2)
                return;
            else
                spriteRenderer.sprite = item.Icon;
        }
        else
            spriteRenderer.sprite = defaultPlayerSprite;
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
        
    public void EquipArmour(ArmourItem armourItem)
    {
        currentArmour = armourItem;
        SwapSprite(currentArmour);
        armourDamageReduction = currentArmour.DamageReduction;
    }

    public void UnequipArmour()
    {
        currentArmour = null;
        SwapSprite(currentArmour);
        armourDamageReduction = 0;
    }

}



