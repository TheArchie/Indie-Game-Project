using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour {

    public Camera cam;

    public float distance;

    public RaycastHit hitInfo;

    [SerializeField]
    private AmmoTest ammoTest;
    [SerializeField]
    private HealingTest healingTest;

    // Use this for initialization
    void Start ()
    {
        ammoTest.GetComponent<AmmoTest>();
        healingTest.GetComponent<HealingTest>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Raycast();
        PickupObject();		
	}

    void Raycast()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hitInfo, distance))
        {
            Debug.Log("The Raycast Detects a " + hitInfo.transform.name);
        }
    }

    void PickupObject()
    {
        HealthPickUp();
        AmmoPickUp();
        NullReference();
    }

    public void NullReference()
    {
        if(Input.GetButtonDown("Interact"))
        {
            if(hitInfo.transform.gameObject.tag == null)
            {
                Debug.Log("No Item to PickUp");
            }else
            {
                Debug.Log(hitInfo.transform.gameObject.name);
            }
        }
    }

    public void HealthPickUp()
    {
        if (Input.GetButtonDown("Interact"))
        {
            if (hitInfo.transform.gameObject != null)
            {
                if (hitInfo.transform.gameObject.tag == "Health")
                {
                    Debug.Log(hitInfo.transform.name + " Picked Up");
                    healingTest.Healing();
                    Destroy(hitInfo.transform.gameObject);
                }
            }
            else
            {
                Debug.Log("Item Not Found");
            }
        }
    }

    public void AmmoPickUp()
    {
        if (Input.GetButtonDown("Interact"))
        {
            if (hitInfo.transform.gameObject != null)
            {
                if (hitInfo.transform.gameObject.tag == "AmmoBox")
                {
                    Debug.Log(hitInfo.transform.name + " Picked Up");
                    ammoTest.AddAmmo();
                    Destroy(hitInfo.transform.gameObject);
                }
            }
            else
            {
                Debug.Log("Item Not Found");
            }
        }
    }
}
