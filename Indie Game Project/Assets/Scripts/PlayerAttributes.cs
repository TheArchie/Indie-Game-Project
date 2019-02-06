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

    public PlayerInformation playerInfo = new PlayerInformation();


	// Use this for initialization
	void Start ()
    {
        playerInfo.playerHealth();
        playerInfo.playerStamina();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
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
}
