using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour {

    [SerializeField]
    private PlayerAttributes playerAttributes;
    [SerializeField]
    private Weapon weapon;
    [SerializeField]
    private Pistol pistol;
    [SerializeField]
    //private GameController gameController;

    public Transform player;
    public Transform hand;
    public Transform gameController;
    public Transform rifle;
    public Transform handgun;
    public Transform cam;
    
    public Canvas skills;
    public Canvas abilites;

    public TextMeshProUGUI healthText;
    public TextMeshProUGUI maxhealthText;
    public TextMeshProUGUI staminaText;
    public TextMeshProUGUI maxstaminaText;
    public TextMeshProUGUI ammoText;
    public TextMeshProUGUI skillPointText;
    public TextMeshProUGUI rifleText;
    public TextMeshProUGUI biggunsText;
    public TextMeshProUGUI pistolText;
    public TextMeshProUGUI meleeText;
    public TextMeshProUGUI medicineText;
    public TextMeshProUGUI scienceText;
    public TextMeshProUGUI speechText;

    private bool inventoryShown;

    public TextMeshProUGUI pistolammoText;

	// Use this for initialization
	void Start ()
    {
        //gameController = GetComponent<GameController>();
        //gameController = gameObject.AddComponent<GameController>();

        skills.enabled = false;
        abilites.enabled = false;
        inventoryShown = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        SettingTexts();
        Test();
        ShowUI();
	}

    void Test()
    {
        if(weapon.enabled == true)
        {
            ammoText.enabled = true;
            //pistolammoText.enabled = false;
        }else
        {
            ammoText.enabled = false;
        }
    }

    void ShowUI()
    {
        if(Input.GetButtonDown("Inventory") && inventoryShown == false)
        {
            skills.enabled = true;
            inventoryShown = true;
            PauseGame();
            //gameController.cursorLock = false;

        }else if(Input.GetButtonDown("Inventory") && inventoryShown == true)
        {
            skills.enabled = false;
            abilites.enabled = false;
            inventoryShown = false;
            UnPauseGame();
            //gameController.cursorLock = true;
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        gameController.GetComponent<GameController>().cursorLock = false;
        gameController.GetComponent<GameController>().LockMouse();
        rifle.GetComponent<Weapon>().enabled = false;
        pistol.GetComponent<Pistol>().enabled = false;
        cam.GetComponent<HeadBobbing>().enabled = false;
        player.GetComponent<PlayerController>().enabled = false;
        hand.GetComponent<SwitchingWeapons>().enabled = false;
    }

    void UnPauseGame()
    {
        Time.timeScale = 1;
        gameController.GetComponent<GameController>().cursorLock = true;
        gameController.GetComponent<GameController>().LockMouse();
        cam.GetComponent<HeadBobbing>().enabled = true;
        player.GetComponent<PlayerController>().enabled = true;
        hand.GetComponent<SwitchingWeapons>().enabled = true;

        if (rifle.GetComponent<WeaponPickUp>().weaponEquipped == true)
        {
            rifle.GetComponent<Weapon>().enabled = true;
        }else
        {
            rifle.GetComponent<Weapon>().enabled = false;
        }

        if(pistol.GetComponent<WeaponPickUp2>().weaponEquipped == true)
        {
            pistol.GetComponent<Pistol>().enabled = true;
        }else
        {
            pistol.GetComponent<Pistol>().enabled = false;
        }
    }

    void SettingTexts()
    {
        healthText.text = "HP: " + playerAttributes.playerInfo.currentHealth.ToString();
        maxhealthText.text = "Health: " + playerAttributes.playerInfo.maxHealth;
        staminaText.text = "Energy: " + playerAttributes.playerInfo.currentStamina.ToString();
        maxstaminaText.text = "Stamina: " + playerAttributes.playerInfo.maxStamina;
        skillPointText.text = "Skill Points: " + playerAttributes.playerAtts.skillPoints;
        rifleText.text = "Rifles: " + playerAttributes.playerSkills.currentRifles;
        biggunsText.text = "Big Guns: " + playerAttributes.playerSkills.currentbigGuns;
        pistolText.text = "Pistols: " + playerAttributes.playerSkills.currentPistols;
        meleeText.text = "Melee: " + playerAttributes.playerSkills.currentMelee;
        medicineText.text = "Medicine: " + playerAttributes.playerSkills.currentMediicne;
        scienceText.text = "Science: " + playerAttributes.playerSkills.currentScience;
        speechText.text = "Speech: " + playerAttributes.playerSkills.currentSpeech;

        if(rifle.GetComponent<WeaponPickUp>().weaponEquipped == true)
        {
            ammoText.text = weapon.currentAmmo + " / " + weapon.maxAmmo;
        }else if(rifle.GetComponent<WeaponPickUp>().weaponEquipped == false)
        {
            ammoText.text = null;
        }

        /*if(pistol.GetComponent<WeaponPickUp2>().weaponEquipped == true)
        {
            pistolammoText.text = pistol.pistolCurrentAmmo + " / " + pistol.pistolMaxAmmo;
        }else
        {
            pistolammoText.text = null;
        }*/
    }

   public void ChangeToAbilities()
    {
        skills.enabled = false;
        abilites.enabled = true;
    }
}
