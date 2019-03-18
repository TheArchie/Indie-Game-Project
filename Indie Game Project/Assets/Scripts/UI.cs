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
    
    public GameObject skills;
    public GameObject abilites;
    public GameObject questWindow;

    public string enemyType;

    public TextMeshProUGUI playerLevelText;
    public TextMeshProUGUI playerLevelText2;
    public TextMeshProUGUI xpText;
    public TextMeshProUGUI xpText2;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI maxhealthText;
    public TextMeshProUGUI staminaText;
    public TextMeshProUGUI maxstaminaText;
    public TextMeshProUGUI ammoText;
    public TextMeshProUGUI skillPointText;
    public TextMeshProUGUI abilityPointsText;
    public TextMeshProUGUI lightweaponsText;
    public TextMeshProUGUI heavyWeaponsText;
    public TextMeshProUGUI handgunsText;
    public TextMeshProUGUI meleeText;
    public TextMeshProUGUI medicineText;
    public TextMeshProUGUI scienceText;
    public TextMeshProUGUI speechText;
    public TextMeshProUGUI warningText;
    public TextMeshProUGUI enemyText;

    public Button healthDecrease;
    public Button staminaDecrease;
    public Button lightweaponDecrease;
    public Button heavyweaponDecrease;
    public Button handgunDecrease;
    public Button meleeDecrease;
    public Button medicineDecrease;
    public Button scienceDecrease;
    public Button speechDecrease;

    private bool inventoryShown;
    public bool questWindowShown;

    public TextMeshProUGUI pistolammoText;

	// Use this for initialization
	void Start ()
    {
        //gameController = GetComponent<GameController>();
        //gameController = gameObject.AddComponent<GameController>();

        skills.SetActive(false);
        abilites.SetActive(false);
        questWindow.SetActive(false);
        inventoryShown = false;
        questWindowShown = false;
        enemyText.enabled = false;

        enemyText.text = enemyType;
	}

    private void OnEnable()
    {
        healthDecrease.interactable = false;
        staminaDecrease.interactable = false;
        lightweaponDecrease.interactable = false;
        heavyweaponDecrease.interactable = false;
        handgunDecrease.interactable = false;
        meleeDecrease.interactable = false;
        medicineDecrease.interactable = false;
        scienceDecrease.interactable = false;
        speechDecrease.interactable = false;
        warningText.enabled = false;
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
            skills.SetActive(true);
            inventoryShown = true;
            PauseGame();
            //gameController.cursorLock = false;

        }else if(Input.GetButtonDown("Inventory") && inventoryShown == true && playerAttributes.playerAtts.skillPoints <= 0 && playerAttributes.playerAtts.abilityPoints <= 0)
        {
            skills.SetActive(false);
            abilites.SetActive(false);
            inventoryShown = false;
            healthDecrease.interactable = false;
            staminaDecrease.interactable = false;
            lightweaponDecrease.interactable = false;
            heavyweaponDecrease.interactable = false;
            handgunDecrease.interactable = false;
            meleeDecrease.interactable = false;
            medicineDecrease.interactable = false;
            scienceDecrease.interactable = false;
            speechDecrease.interactable = false;
            warningText.enabled = false;
            playerAttributes.pointsAdded.lightWeaponsPointsAdded = 0;
            playerAttributes.pointsAdded.heavyWeaponsPointsAdded = 0;
            playerAttributes.pointsAdded.handgunsPointsAdded = 0;
            playerAttributes.pointsAdded.meleePointsAdded = 0;
            playerAttributes.pointsAdded.medicinePointsAdded = 0;
            playerAttributes.pointsAdded.sciencePointsAdded = 0;
            playerAttributes.pointsAdded.speechAdded = 0;
            UnPauseGame();
            //gameController.cursorLock = true;
        }else if(Input.GetButtonDown("Inventory") && inventoryShown == true && playerAttributes.playerAtts.skillPoints >= 1 && playerAttributes.playerAtts.abilityPoints >= 1)
        {
            warningText.enabled = true;
        }
    }

    public void PauseGame()
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

    public void UnPauseGame()
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
        playerLevelText.text = "Level: " + playerAttributes.playerAtts.playerLevel;
        playerLevelText2.text = "Level: " + playerAttributes.playerAtts.playerLevel;
        xpText.text = "Expereince: " + playerAttributes.playerAtts.currentXp + " / " + playerAttributes.playerAtts.xpNextLevel; 
        xpText2.text = "Expereince: " + playerAttributes.playerAtts.currentXp + " / " + playerAttributes.playerAtts.xpNextLevel; 
        healthText.text = "HP: " + playerAttributes.playerInfo.currentHealth.ToString();
        maxhealthText.text = "Health: " + playerAttributes.playerInfo.maxHealth;
        staminaText.text = "Energy: " + playerAttributes.playerInfo.currentStamina.ToString();
        maxstaminaText.text = "Stamina: " + playerAttributes.playerInfo.maxStamina;
        skillPointText.text = "Skill Points: " + playerAttributes.playerAtts.skillPoints;
        abilityPointsText.text = "Ability Points: " + playerAttributes.playerAtts.abilityPoints;
        lightweaponsText.text = "Light Weapons: " + playerAttributes.playerSkills.currentRifles;
        heavyWeaponsText.text = "Heavy Weapons: " + playerAttributes.playerSkills.currentbigGuns;
        handgunsText.text = "Handguns: " + playerAttributes.playerSkills.currentPistols;
        meleeText.text = "Melee: " + playerAttributes.playerSkills.currentMelee;
        medicineText.text = "Medicine: " + playerAttributes.playerSkills.currentMediicne;
        scienceText.text = "Science: " + playerAttributes.playerSkills.currentScience;
        speechText.text = "Speech: " + playerAttributes.playerSkills.currentSpeech;

        /*if(rifle.GetComponent<WeaponPickUp>().weaponEquipped == true)
        {
            ammoText.text = weapon.currentAmmo + " / " + weapon.maxAmmo;
        }else if(rifle.GetComponent<WeaponPickUp>().weaponEquipped == false)
        {
            ammoText.text = null;
        }

        if(pistol.GetComponent<WeaponPickUp2>().weaponEquipped == true)
        {
            pistolammoText.text = pistol.pistolCurrentAmmo + " / " + pistol.pistolMaxAmmo;
        }else
        {
            pistolammoText.text = null;
        }*/
    }

    public void ChangeToAbilities()
    {
        skills.SetActive(false);
        abilites.SetActive(true);
    }

    public void ChangetoSkills()
    {
        skills.SetActive(true);
        abilites.SetActive(false);
    }
}
