using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour
{
    public Text levelText, hitpointText, friesText, expText;
    public Image currentArmorSprite;
    public Image weaponSprite;
    public GameObject expBar;
    public UnityEvent onMenuDataChanged = new UnityEvent();
    private Image expBarColor;
    private RectTransform expBarRect;
    [SerializeField] private Text weaponDamage;
    [SerializeField] private Text armourDamageReduction;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        onMenuDataChanged.AddListener(UpdateMenu);
    }
        

    private void OnDestroy()
    {
        onMenuDataChanged.RemoveListener(UpdateMenu);
    }

    public void OnArmorEquip()
    {
        if (GameManager.instance.player.CurrentArmour == null)
            currentArmorSprite.sprite = GameManager.instance.player.DefaultPlayerSprite;
        else 
            currentArmorSprite.sprite = GameManager.instance.player.CurrentArmour.Icon;
        armourDamageReduction.text = "Damage Reduction - " + GameManager.instance.player.armourDamageReduction.ToString();
    }

    // Update charater information

    public void UpdateMenu()
    {
        //Weapon
        if (GameManager.instance.weapon.gameObject.activeSelf)
        {
            weaponSprite.enabled = true;
            weaponSprite.sprite = GameManager.instance.weapon.GetComponent<SpriteRenderer>().sprite;
            weaponDamage.text = "Damage - " + (GameManager.instance.weapon.WeaponLevel + 1).ToString();
        }
        else
        {
            weaponSprite.enabled = false;
            weaponDamage.text = "Damage - 0";
        }


        //Meta
        levelText.text = GameManager.instance.GetCurrentLevel().ToString();
        hitpointText.text = GameManager.instance.player.hitpoints.ToString() + "/" + GameManager.instance.player.maxHitpoints.ToString();
        friesText.text = GameManager.instance.fries.ToString();


        //EXP BAR

        expBarRect = expBar.GetComponent<RectTransform>();
        int currentLevel = GameManager.instance.GetCurrentLevel();

        if(currentLevel == GameManager.instance.xpTable.Count)
        {
            expText.text = GameManager.instance.exp.ToString() + "total experience point";

            expBarColor = expBar.GetComponent<Image>();
            expBarColor.color = Color.yellow;
            expBarRect.localScale = Vector3.one;
        }
        else
        {
            int prevLevelExp = GameManager.instance.GetXpToLevel(currentLevel - 1);
            int currentLevelExp = GameManager.instance.GetXpToLevel(currentLevel);

            int diff = currentLevelExp - prevLevelExp;

            int currentExpIntoLevel = GameManager.instance.exp - prevLevelExp;

            float completionRatio = (float)currentExpIntoLevel / (float)diff;

            expBarRect.localScale = new Vector3(completionRatio, 1, 1);

            expText.text = currentExpIntoLevel.ToString() + "/" + diff.ToString();
        }

        //Armour
        OnArmorEquip();
        
    }
    
}
