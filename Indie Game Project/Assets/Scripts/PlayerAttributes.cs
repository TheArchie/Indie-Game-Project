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
    }

    public PlayerInformation playerInfo = new PlayerInformation();


	// Use this for initialization
	void Start ()
    {
        playerInfo.currentHealth = playerInfo.maxHealth;
        Debug.Log("Health is " + playerInfo.currentHealth);
        playerInfo.currentStamina = playerInfo.maxStamina;
        Debug.Log("Stamina is " + playerInfo.currentStamina);
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
    }
}
