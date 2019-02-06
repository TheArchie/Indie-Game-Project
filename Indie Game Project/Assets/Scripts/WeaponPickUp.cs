using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour {

    public GameObject hand;
    public GameObject obj;
    public Collider boxCollider;
    public Weapon weaponScript;

    public bool weaponEquipped;

    public float xPos;
    public float yPos;
    public float zPos;

    // Use this for initialization
    void Start()
    {
        weaponScript = GetComponent<Weapon>();
        weaponScript.enabled = false;
        weaponEquipped = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        hand.SetActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {
        obj.transform.SetParent(hand.transform, false);
        transform.localPosition = new Vector3(xPos, yPos, zPos);
        weaponScript.enabled = true;
        hand.SetActive(true);
        weaponEquipped = true;
        {
            Debug.Log("Weapon is Equipped");
        }
        Destroy(boxCollider);

        if(weaponEquipped == true)
        {

        }
    }
}
