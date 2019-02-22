using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingTest : MonoBehaviour {

    [SerializeField]
    private float healingEffect;
    public float healingAmount;

    public PlayerAttributes playerAttributes;

	// Use this for initialization
	void Start ()
    {
        GameObject player = GameObject.Find("Player");

        playerAttributes = GetComponent<PlayerAttributes>();
        playerAttributes = GameObject.Find("Player").GetComponent<PlayerAttributes>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        CalculateHealingAmount();
	}

    /*private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        playerAttributes.playerInfo.currentHealth += healingEffect;
        Debug.Log(healingEffect + " was Just Added to Player Health");
    }*/

    void CalculateHealingAmount()
    {
        var calculation = playerAttributes.playerSkills.currentMediicne / 50;
        var calculation2 = calculation + 1;
        healingEffect = Mathf.Round(healingAmount * calculation2);
    }

    public void Healing()
    {
        playerAttributes.playerInfo.currentHealth += healingEffect;
        Debug.Log(healingEffect + " was Just Added to Player Health");
        //Destroy(gameObject);
    }
}
