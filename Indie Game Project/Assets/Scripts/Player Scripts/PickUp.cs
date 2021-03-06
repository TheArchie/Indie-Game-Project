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
    //[SerializeField]
    //private MissionGiver missionGiver;

    [SerializeField]
    private Door door;

    public bool hasKey;

    public PlayerAttributes player;
    public UI uiController;

    public int shipParts;
    public int maxshipParts = 2;

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

        player = FindObjectOfType<PlayerAttributes>();
        uiController = FindObjectOfType<UI>();
        //uiController.GetComponent<UI>();

        hasKey = false;

        shipParts = 0;
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
            //Debug.Log(hitInfo.transform.name);
            PickupObject();
            //NPCInteraction();
        }
    }

    void PickupObject()
    {
        if(Input.GetButtonDown("Interact"))
        {
            Debug.Log("Item Picked Up");

            if(hitInfo.transform.gameObject.tag == "Health")
            {
                Debug.Log("This is a " + hitInfo.transform.name);
                healingTest.Healing();
                Destroy(hitInfo.transform.gameObject);
            }

            if(hitInfo.transform.gameObject.tag == "AmmoBox")
            {
                Debug.Log("This is a " + hitInfo.transform.name);
                ammoTest.AddAmmo();
                Destroy(hitInfo.transform.gameObject);
            }

            if (hitInfo.transform.gameObject.tag == "PickUP")
            {
                Debug.Log("This is a " + hitInfo.transform.name);
                Destroy(hitInfo.transform.gameObject);
            }

            if(hitInfo.transform.gameObject.tag == "Computer" && player.playerSkills.currentScience >= 25)
            {
                Debug.Log("Use Computer");
                uiController.EnableDesktop();
            }else if(hitInfo.transform.gameObject.tag == "Computer" && player.playerSkills.currentScience <= 24)
            {
                Debug.Log("Science Skill Not High Enough");
            }

            if(hitInfo.transform.gameObject.tag == "Key")
            {
                Destroy(hitInfo.transform.gameObject);
                //Destroy(hitInfo.transform.parent.gameObject);
                hasKey = true;
                Debug.Log("Key Added");
            }

            if(hitInfo.transform.gameObject.tag == "EscapePod")
            {
                if(hasKey == true)
                {
                    uiController.PauseGame();
                    uiController.winScreen.SetActive(true);
                }else if (hasKey == false)
                {
                    StartCoroutine(KeyRequiredText());
                    Debug.Log("I need the Ships Key!!");
                }

            }
        }
    }

    IEnumerator KeyRequiredText()
    {
        uiController.objectiveText.enabled = true;
        uiController.objectiveText.text = "Key Required! I should look around some more";
        yield return new WaitForSeconds(5f);
        uiController.objectiveText.enabled = false;
    }

    /*if (hitInfo.transform.gameObject.tag == "RepairPart")
    {
        promptText.enabled = true;
        promptText.text = "Press E to Pickup " + hitInfo.transform.gameObject.name;
        promptText.color = Color.white;
    }*/
}

    /*void NPCInteraction()
    {
        if (Input.GetButtonDown("Interact") && missionGiver.missionWindowActive == false)
        {
            if (hitInfo.transform.gameObject.tag == "NPC")
            {
                Debug.Log("I'm an NPC");
                missionGiver.ShowUI();
            }else if(Input.GetButtonDown("Interact") && missionGiver.missionWindowActive == true)
            {
                missionGiver.HideUI();
            }
        }
    }*/
