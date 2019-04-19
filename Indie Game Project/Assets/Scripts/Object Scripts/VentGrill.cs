﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentGrill : MonoBehaviour {

    public float health = 1.0f;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Damage(float amountofDamage)
    {
        health -= amountofDamage;
        if (health <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        Destroy(gameObject);
    }
}