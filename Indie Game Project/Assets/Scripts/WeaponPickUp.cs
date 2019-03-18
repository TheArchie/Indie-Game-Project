using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour {

    public GameObject weapon;

    public GameObject hand;
    public GameObject obj;
    public Collider boxCollider;

    [SerializeField]
    private Weapon weaponScript;
    [SerializeField]
    private Pistol pistolScript; 

    public SwitchingWeapons weaponSwitch;

    public string currentWeapon;

    public bool weaponEquipped;
    public bool pistolEquipped;

    public float xPos;
    public float yPos;
    public float zPos;

    // Use this for initialization
    void Start()
    {
        // weaponScript = GetComponent<Weapon>();
        weaponScript.enabled = false;
        pistolScript.enabled = false;
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
        if(weaponEquipped == true && pistolEquipped == true)
        {
            weaponScript.enabled = true;
            pistolScript.enabled = true;
        }

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
            transform.localPosition = new Vector3(xPos, yPos, zPos);
            GetComponent<BoxCollider>().enabled = false;
            print(currentWeapon);
            obj.SetActive(false);
            Debug.Log("Pick Up");

            if(gameObject.name == "Rifle")
            {
                weaponScript.enabled = true;
                weaponEquipped = true;
                Debug.Log("Rifle Equipped");
            }

            if(gameObject.name == "Pistol")
            {
                pistolScript.enabled = true;
                pistolEquipped = true;
                Debug.Log("Pistol Equipped");
            }
        }
    }
}
