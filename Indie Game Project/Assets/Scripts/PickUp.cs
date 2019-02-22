﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

    public Camera cam;

    public float distance;

    public RaycastHit hitInfo;

    [SerializeField]
    private HealingTest healingTest;
    [SerializeField]
    private AmmoTest ammoTest;


	// Use this for initialization
	void Start ()
    {
        //healingTest.GetComponent<HealingTest>();
        //ammoTest.GetComponent<AmmoTest>();

        GameObject healthKit = GameObject.Find("Health Pickup");
        healingTest = GetComponent<HealingTest>();
        healingTest = GameObject.Find("Health Pickup").GetComponent<HealingTest>();

        GameObject ammoBox = GameObject.Find("AmmoBox");
        ammoTest = GetComponent<AmmoTest>();
        ammoTest = GameObject.Find("AmmoBox").GetComponent<AmmoTest>();
    }

    private void OnEnable()
    {
        var Player = GameObject.Find("AmmoBox");
    }

    // Update is called once per frame
    void Update ()
    {
        Raycast();
	}

    void Raycast()
    {
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hitInfo, distance))
        {
            Debug.Log(hitInfo.transform.name);
            PickupObject();
        }
    }

    void PickupObject()
    {
        if(Input.GetButtonDown("Interact"))
        {
            Debug.Log("Item Picked Up");

            if(hitInfo.transform.gameObject.tag == "Health")
            {
                Debug.Log("This is a Health Pickup");
                healingTest.Healing();
                Destroy(hitInfo.transform.gameObject);
            }

            if(hitInfo.transform.gameObject.tag == "AmmoBox")
            {
                Debug.Log("This is an Ammo Box");
                ammoTest.AddAmmo();
                Destroy(hitInfo.transform.gameObject);
            }
            
        }
    }
}
