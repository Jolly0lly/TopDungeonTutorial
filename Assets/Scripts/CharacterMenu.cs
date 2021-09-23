using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour
{
    public Text levelText, hitpointText, friesText, expText;

    private int currentArmor = 0;
    public Image currentArmorSprite;
    public Image weaponSprite;
    public GameObject expBar;
    private Image expBarColor;
    private RectTransform expBarRect;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }


    public void OnArmorEquip(Item item)
    {
        currentArmorSprite.sprite = item.Icon;
        GameManager.instance.player.SwapSprite(item);
    }

    public void OnWeaponUpgrade()
    {
        if (GameManager.instance.TryUpgradeWeapon())
        {
            UpdateMenu();
        }
    }

    // Update charater information

    public void UpdateMenu()
    {
        //Weapon

        weaponSprite.sprite = GameManager.instance.weaponSprites[0];

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


        
    }
    
}
