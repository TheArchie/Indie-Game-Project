using System.Collections;
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
    [SerializeField]
    private MissionGiver missionGiver;

    public Door door;


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

        door.GetComponent<Door>();
    }

    private void OnEnable()
    {
        var Player = GameObject.Find("AmmoBox");
    }

    // Update is called once per frame
    void Update ()
    {
        Raycast();
        OpenDoor();
	}

    void Raycast()
    {
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hitInfo, distance))
        {
            Debug.Log(hitInfo.transform.name);
            PickupObject();
            NPCInteraction();
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

    void NPCInteraction()
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
    }

    public void OpenDoor()
    {
        if(Input.GetButtonDown("Interact"))
        {
            if(hitInfo.transform.gameObject.tag == "Door" && door.isOpening == false)
            {
                Debug.Log("Its a Door");

                StartCoroutine(door.OpenDoor());
            }else if(Input.GetButtonDown("Interact"))
            {
                if (hitInfo.transform.gameObject.tag == "Door" && door.isOpening == true)
                {
                    StartCoroutine(door.CloseDoor());
                }
            }
        }
    }
}
