using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp2 : MonoBehaviour {

    public GameObject hand;
    public GameObject obj;
    public Collider boxCollider;
    public Weapon weaponScript;

    public SwitchingWeapons weaponSwitch;

    public string currentWeapon;

    public bool weaponEquipped;

    public float xPos;
    public float yPos;
    public float zPos;

    // Use this for initialization
    void Start()
    {
        weaponScript = GetComponent<Weapon>();
        weaponScript.enabled = false;
        weaponSwitch.GetComponent<SwitchingWeapons>();
        weaponEquipped = false;
        {
            Debug.Log("Weapon not Equipped");
        }
        currentWeapon = gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*void OnTriggerEnter(Collider other)
    {
        if(Input.GetButton("Interact"))
        {
            obj.transform.SetParent(hand.transform, false);
            transform.localPosition = new Vector3(xPos, yPos, zPos);
            weaponScript.enabled = true;
            GetComponent<BoxCollider>().enabled = false;
            print(currentWeapon);
            weaponEquipped = true;
        }       
    }*/

    void OnTriggerStay(Collider other)
    {
        if (Input.GetButton("Interact"))
        {
            obj.transform.SetParent(hand.transform, false);
            obj.SetActive(false);
            transform.localPosition = new Vector3(xPos, yPos, zPos);
            weaponScript.enabled = true;
            GetComponent<BoxCollider>().enabled = false;
            print(currentWeapon);
            weaponEquipped = true;
            Debug.Log("Pick Up");
        }
    }
}
