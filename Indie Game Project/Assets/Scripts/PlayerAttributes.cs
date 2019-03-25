using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour {

    [System.Serializable]
    public class PlayerInformation
    {
        public float currentHealth;
        public float currentStamina;
        public float maxHealth = 100f;
        public float maxStamina = 100f;

        public bool playerisDead;

        public void playerHealth()
        {
            currentHealth = maxHealth;
            Debug.Log("Health is " + currentHealth);
        }
        public void playerStamina()
        {
            currentStamina = maxStamina;
            Debug.Log("Stamina is " + currentStamina);
        }
    }

    [System.Serializable]
    public class PlayerLevels
    {
        public int playerLevel;
        public float currentXp;
        public float xpNextLevel;

        public int abilityPoints;
        public int skillPoints;
    }

    [System.Serializable]
    public class PlayerSkills
    {
        public float maxRifles = 100f;
        public float currentRifles = 15f;

        public float maxbigGuns = 100f;
        public float currentbigGuns = 15f;

        public float maxPistols = 100f;
        public float currentPistols = 15f;

        public float maxMelee = 100f;
        public float currentMelee = 15f;

        public float maxMediicne = 100f;
        public float currentMediicne = 15f;

        public float maxScience = 100f;
        public float currentScience = 15f;

        public float maxSpeech = 100f;
        public float currentSpeech = 15f;
    }

    [System.Serializable]
    public class PointsAdded
    {
        public int lightWeaponsPointsAdded;
        public int heavyWeaponsPointsAdded;
        public int handgunsPointsAdded;
        public int meleePointsAdded;
        public int medicinePointsAdded;
        public int sciencePointsAdded;
        public int speechAdded;
    }

    public PlayerInformation playerInfo = new PlayerInformation();
    public PlayerLevels playerAtts = new PlayerLevels();
    public PlayerSkills playerSkills = new PlayerSkills();
    [HideInInspector]
    public PointsAdded pointsAdded = new PointsAdded();

    [SerializeField]
    private UI UIController;

    public List<Mission> missions = new List<Mission>();

	// Use this for initialization
	void Start ()
    {
        playerInfo.playerHealth();
        playerInfo.playerStamina();

        playerAtts.playerLevel = 1;
        playerAtts.currentXp = 0f;
        playerAtts.xpNextLevel = 250f;
        playerAtts.abilityPoints = 0;
        playerAtts.skillPoints = 0;

        //List<Mission> missions = new List<Mission>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        Experience();

        if(Input.GetKeyDown(KeyCode.Keypad1))
        {
            playerAtts.currentXp += 50;
            //playerSkills.currentRifles += 10;
        }
        SetAttributes();
	}

    public void DamagePlayer(float damageAmount)
    {
        playerInfo.currentHealth -= damageAmount;
        if(playerInfo.currentHealth <= 0)
        {
            Debug.Log("Player has Died");
            Die();
        }

    }

    public void Die()
    {
        Destroy(gameObject);
        playerInfo.playerisDead = true;
        {
            Debug.Log("Dead");
        }
    }

    public void SetAttributes() //Set All the Player skills so that they can have a mximum value of 100 and can not progress further
    {
        if(playerInfo.currentHealth >= playerInfo.maxHealth)
        {
            playerInfo.currentHealth = playerInfo.maxHealth;
        }

        if (playerSkills.currentRifles >= playerSkills.maxRifles)
        {
            playerSkills.currentRifles = playerSkills.maxRifles;
        }

        if (playerSkills.currentPistols >= playerSkills.maxPistols)
        {
            playerSkills.currentPistols = playerSkills.maxPistols;
        }

        if (playerSkills.currentbigGuns >= playerSkills.maxbigGuns)
        {
            playerSkills.currentbigGuns = playerSkills.maxbigGuns;
        }

        if (playerSkills.currentMelee >= playerSkills.maxMelee)
        {
            playerSkills.currentMelee = playerSkills.maxMelee;
        }

        if (playerSkills.currentScience >= playerSkills.maxScience)
        {
            playerSkills.currentScience = playerSkills.maxScience;
        }

        if (playerSkills.currentMediicne >= playerSkills.maxMediicne)
        {
            playerSkills.currentMediicne = playerSkills.maxMediicne;
        }

        if (playerSkills.currentSpeech >= playerSkills.maxSpeech)
        {
            playerSkills.currentSpeech = playerSkills.maxSpeech;
        }
    }

    public void staminaLoss(float stamina)
    {
        playerInfo.currentStamina -= stamina;
        {
            if(playerInfo.currentStamina <= 0)
            {
                playerInfo.currentStamina = 0;
            }          
        }
    }

    public void staminaGain(float stamina)
    {
        playerInfo.currentStamina += stamina;
        {
            if(playerInfo.currentStamina >= playerInfo.maxStamina)
            {
                playerInfo.currentStamina = playerInfo.maxStamina;
            }
        }
    }

    public void LevelUp()
    {
        playerAtts.playerLevel += 1;
        playerAtts.currentXp = playerAtts.currentXp - playerAtts.xpNextLevel;
        playerAtts.abilityPoints += 1;
        playerAtts.skillPoints += 15;

        playerAtts.xpNextLevel = Mathf.Round(playerAtts.xpNextLevel * 1.5f);

        Debug.Log("Levelled Up!");
    }

    public void Experience()
    {
        if (playerAtts.currentXp >= playerAtts.xpNextLevel)
            LevelUp();
    }

    public void IncreaseHealth()
    {
            if(playerAtts.abilityPoints >= 1)
            {
                playerInfo.maxHealth = playerInfo.maxHealth += 10;
                Debug.Log("Health Increased");
                playerAtts.abilityPoints -= 1;
                UIController.healthDecrease.interactable = true;
            }else if(playerAtts.abilityPoints <= 0)
            {
                Debug.Log("Not Enough Ability Points");
                return;
            }        
    }

    public void DecreaseHealth()
    {
        playerInfo.maxHealth = playerInfo.maxHealth -= 10;
        playerAtts.abilityPoints += 1;
        UIController.healthDecrease.interactable = false;
    }

    public void IncreaseStamina()
    {
        if (playerAtts.abilityPoints >= 1)
        {
            playerInfo.maxStamina = playerInfo.maxStamina += 10;
            Debug.Log("Stamina Increased");
            playerAtts.abilityPoints -= 1;
            UIController.staminaDecrease.interactable = true;
        }
        else if (playerAtts.abilityPoints <= 0)
        {
            Debug.Log("Not Enough Ability Points");
            return;
        }
    }

    public void DecreaseStamina()
    {
        playerInfo.maxHealth = playerInfo.maxStamina -= 10;
        playerAtts.abilityPoints += 1;
        UIController.staminaDecrease.interactable = false;
    }

    public void IncreaseLightWeaponStat()
    {
        if(playerAtts.skillPoints >= 1)
        {
            playerSkills.currentRifles++;
            playerAtts.skillPoints--;
            UIController.lightweaponDecrease.interactable = true;
            pointsAdded.lightWeaponsPointsAdded++;
            Debug.Log("Light Weapons Points Added is " + pointsAdded.lightWeaponsPointsAdded);
        }
    }

    public void DecreaseLightWeaponStat()
    {
        playerSkills.currentRifles--;
        playerAtts.skillPoints++;
        pointsAdded.lightWeaponsPointsAdded--;

        if(pointsAdded.lightWeaponsPointsAdded <= 0)
        {
            UIController.lightweaponDecrease.interactable = false;
            pointsAdded.lightWeaponsPointsAdded = 0;
        }
    }

    public void IncreaseHeavyWeaponStat()
    {
        if (playerAtts.skillPoints >= 1)
        {
            playerSkills.currentbigGuns++;
            playerAtts.skillPoints--;
            UIController.heavyweaponDecrease.interactable = true;
            pointsAdded.heavyWeaponsPointsAdded++;
            Debug.Log("Heavy Weapons Points Added is " + pointsAdded.heavyWeaponsPointsAdded);
        }
    }

    public void DecreaseHeavyWeaponStat()
    {
        playerSkills.currentbigGuns--;
        playerAtts.skillPoints++;
        pointsAdded.heavyWeaponsPointsAdded--;

        if (pointsAdded.heavyWeaponsPointsAdded <= 0)
        {
            UIController.heavyweaponDecrease.interactable = false;
            pointsAdded.heavyWeaponsPointsAdded = 0;
        }
    }

    public void IncreaseHandgunsStat()
    {
        if (playerAtts.skillPoints >= 1)
        {
            playerSkills.currentPistols++;
            playerAtts.skillPoints--;
            UIController.handgunDecrease.interactable = true;
            pointsAdded.handgunsPointsAdded++;
            Debug.Log("Handguns Points Added is " + pointsAdded.handgunsPointsAdded);
        }
    }

    public void DecreaseHandgunStat()
    {
        playerSkills.currentPistols--;
        playerAtts.skillPoints++;
        pointsAdded.handgunsPointsAdded--;

        if (pointsAdded.handgunsPointsAdded <= 0)
        {
            UIController.handgunDecrease.interactable = false;
            pointsAdded.handgunsPointsAdded = 0;
        }
    }

    public void IncreaseMeleeStat()
    {
        if (playerAtts.skillPoints >= 1)
        {
            playerSkills.currentMelee++;
            playerAtts.skillPoints--;
            UIController.meleeDecrease.interactable = true;
            pointsAdded.meleePointsAdded++;
            Debug.Log("Melee Points Added is " + pointsAdded.meleePointsAdded);
        }
    }

    public void DecreaseMeleeStat()
    {
        playerSkills.currentMelee--;
        playerAtts.skillPoints++;
        pointsAdded.meleePointsAdded--;

        if (pointsAdded.meleePointsAdded <= 0)
        {
            UIController.meleeDecrease.interactable = false;
            pointsAdded.meleePointsAdded = 0;
        }
    }

    public void IncreaseMedicineStat()
    {
        if (playerAtts.skillPoints >= 1)
        {
            playerSkills.currentMediicne++;
            playerAtts.skillPoints--;
            UIController.medicineDecrease.interactable = true;
            pointsAdded.medicinePointsAdded++;
            Debug.Log("Medicine Points Added is " + pointsAdded.medicinePointsAdded);
        }
    }

    public void DecreaseMedicineStat()
    {
        playerSkills.currentMediicne--;
        playerAtts.skillPoints++;
        pointsAdded.medicinePointsAdded--;

        if (pointsAdded.medicinePointsAdded <= 0)
        {
            UIController.medicineDecrease.interactable = false;
            pointsAdded.medicinePointsAdded = 0;
        }
    }

    public void IncreaseScienceStat()
    {
        if (playerAtts.skillPoints >= 1)
        {
            playerSkills.currentScience++;
            playerAtts.skillPoints--;
            UIController.scienceDecrease.interactable = true;
            pointsAdded.sciencePointsAdded++;
            Debug.Log("Science Points Added is " + pointsAdded.sciencePointsAdded);
        }
    }

    public void DecreaseSciecneStat()
    {
        playerSkills.currentScience--;
        playerAtts.skillPoints++;
        pointsAdded.sciencePointsAdded--;

        if (pointsAdded.sciencePointsAdded <= 0)
        {
            UIController.scienceDecrease.interactable = false;
            pointsAdded.sciencePointsAdded = 0;
        }
    }

    public void IncreaseSpeechStat()
    {
        if (playerAtts.skillPoints >= 1)
        {
            playerSkills.currentSpeech++;
            playerAtts.skillPoints--;
            UIController.speechDecrease.interactable = true;
            pointsAdded.speechAdded++;
            Debug.Log("Speech Points Added is " + pointsAdded.speechAdded);
        }
    }

    public void DecreaseSpeechStat()
    {
        playerSkills.currentSpeech--;
        playerAtts.skillPoints++;
        pointsAdded.speechAdded--;

        if (pointsAdded.speechAdded <= 0)
        {
            UIController.speechDecrease.interactable = false;
            pointsAdded.speechAdded = 0;
        }
    }


}
