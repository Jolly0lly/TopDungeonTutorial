using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int fries;
    public int exp;
    public static GameManager instance;
    private void Awake()
    {
        if(GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        SceneManager.sceneLoaded += LoadState;  //data storing issues
        SceneManager.sceneLoaded += OnSceneLoaded;
        DontDestroyOnLoad(gameObject);
      

    }
    //Resources

    public List<Sprite> armorSprites;
    public List<Sprite> weaponSprites;
    public List<int> xpTable;
    public List<int> weaponPrices;

    //References 
    public Player player;

    public Armour armor;
    public Weapon weapon;

    public FloatingTextManager floatingTextManager;
    public RectTransform hpBar;

    //Logic

    //Floating text

    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }

    //Game Saves
    /*
     * INT preferedSkin
     * INT fries
     * INT exp
     * INT weaponLevel
     */

    //Upgrade weapon

    public bool TryUpgradeWeapon()
    {
        // is the weapon max level

        if (weaponPrices.Count < weapon.WeaponLevel)
            return false;

        if (fries >= weaponPrices[weapon.WeaponLevel])
        {
            fries -= weaponPrices[weapon.WeaponLevel];
            weapon.UpgradeWeapon();

            return true;
        }

        return false;
    }


    // leveling system

    public int learningPoints;


    public int GetCurrentLevel()
    {
        int currentLevel = 0;
        int add = 0;
        
        while(exp >= add)
        {
            add += xpTable[currentLevel];
            currentLevel++;

            if (currentLevel == xpTable.Count)
                return currentLevel; // Max Level
        }

        return currentLevel;
    }

    public int GetXpToLevel(int level)
    {
        int r = 0;
        int exp = 0;

        while (r < level)
        {
            exp += xpTable[r]; ;
            r++;
        }

        return exp;
    }

    public void GrantExp (int experience)
    {
        int currentLevel = GetCurrentLevel();
        exp += experience;

        if (currentLevel < GetCurrentLevel())
        {
            OnLevelUp();
        }
    }

    public void OnLevelUp()
    {
        Debug.Log("LevelUP");
        player.OnLevelUp();
    }

    public void OnSceneLoaded(Scene s, LoadSceneMode mode)
    {
        player.transform.position = GameObject.Find("SpawnPoint").transform.position;
    }


    

    public void SaveState()
    {
        Debug.Log("SaveState");
        string s = "";

        s += "0" + "|";
        s += fries.ToString() + "|";
        s += exp.ToString() + "|";
        s += weapon.WeaponLevel.ToString();
        s += learningPoints.ToString();
        PlayerPrefs.SetString("SaveState", s);
    } 

    public void LoadState(Scene s, LoadSceneMode mode)
    {
        //SceneManager.sceneLoaded -= LoadState;
        if (!PlayerPrefs.HasKey("SaveState"))
            return;

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');
        // "0 - preferred skin| 10 - amount of fries | 15 - exp | 2 - weapon level | 5 - learning points"
        //Change player skin
        fries = int.Parse(data[1]);

        //Experience and leveling

        exp = int.Parse(data[2]);
        player.SetLevel(GetCurrentLevel());


        //Weapon
        //weapon.WeaponLevel = int.Parse(data[3]);


       // learningPoints = int.Parse(data[4]);

        
        Debug.Log("LoadState");
    }
 

}
