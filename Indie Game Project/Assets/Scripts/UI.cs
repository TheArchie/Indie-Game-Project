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

    //public TextMeshProUGUI pistolammoText;

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
            //gameController.cursorLock = false;

        }else if(Input.GetButtonDown("Inventory") && inventoryShown == true)
        {
            skills.enabled = false;
            inventoryShown = false;
            //gameController.cursorLock = true;
        }
    }

    void SettingTexts()
    {
        healthText.text = "HP: " + playerAttributes.playerInfo.currentHealth.ToString();
        maxhealthText.text = "Health: " + playerAttributes.playerInfo.maxHealth;
        staminaText.text = "Energy: " + playerAttributes.playerInfo.currentStamina.ToString();
        maxstaminaText.text = "Stamina: " + playerAttributes.playerInfo.maxStamina;
        ammoText.text = weapon.currentAmmo + " / " + weapon.maxAmmo;
        skillPointText.text = "Skill Points: " + playerAttributes.playerAtts.skillPoints;
        rifleText.text = "Rifles: " + playerAttributes.playerSkills.currentRifles;
        biggunsText.text = "Big Guns: " + playerAttributes.playerSkills.currentbigGuns;
        pistolText.text = "Pistols: " + playerAttributes.playerSkills.currentPistols;
        meleeText.text = "Melee: " + playerAttributes.playerSkills.currentMelee;
        medicineText.text = "Medicine: " + playerAttributes.playerSkills.currentMediicne;
        scienceText.text = "Science: " + playerAttributes.playerSkills.currentScience;
        speechText.text = "Speech: " + playerAttributes.playerSkills.currentSpeech;
        //pistolammoText.text = pistol.pistolCurrentAmmo + " / " + pistol.pistolMaxAmmo;
    }
}
