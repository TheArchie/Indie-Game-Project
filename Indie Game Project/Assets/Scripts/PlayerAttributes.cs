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

    public PlayerInformation playerInfo = new PlayerInformation();
    public PlayerLevels playerAtts = new PlayerLevels();


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
    }
	
	// Update is called once per frame
	void Update ()
    {
        Experience();

        if(Input.GetKeyDown(KeyCode.Keypad1))
        {
            playerAtts.currentXp += 50;
        }

        IncreaseHealth();
		
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
            if(playerInfo.currentStamina >= 100)
            {
                playerInfo.currentStamina = 100;
            }
        }
    }

    public void LevelUp()
    {
        playerAtts.playerLevel += 1;
        playerAtts.currentXp = playerAtts.currentXp - playerAtts.xpNextLevel;
        playerAtts.abilityPoints += 1;
        playerAtts.skillPoints += 15;

        playerAtts.xpNextLevel = playerAtts.xpNextLevel * 1.5f;

        Debug.Log("Levelled Up!");
    }

    public void Experience()
    {
        if (playerAtts.currentXp >= playerAtts.xpNextLevel)
            LevelUp();
    }

    public void IncreaseHealth()
    {
        if(Input.GetKeyDown(KeyCode.Keypad2))
        {
            if(playerAtts.abilityPoints >= 1)
            {
                playerInfo.maxHealth = playerInfo.maxHealth + 10;
                Debug.Log("Health Increased");
                playerAtts.abilityPoints -= 1;
            }else if(playerAtts.abilityPoints <= 0)
            {
                Debug.Log("Not Enough Ability Points");
                return;
            }
        }
    }
}
