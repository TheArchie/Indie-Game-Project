using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoTest : MonoBehaviour {

    public Weapon weapon;

    public int ammoAmount;

	// Use this for initialization
	public void Start ()
    {
        GameObject rifle = GameObject.Find("Rifle");

        weapon = GetComponent<Weapon>();
        weapon = GameObject.Find("Rifle").GetComponent<Weapon>();

        ammoAmount = Random.Range(6, 20);
	}
	
	// Update is called once per frame
	public void Update ()
    {
		
	}

    public void fart()
    {
        Debug.Log("Fart");
    }

    public void AddAmmo()
    {
        weapon.maxAmmo += ammoAmount;
        Debug.Log(ammoAmount +  " Was Added");
        //Destroy(gameObject);
    }
}
