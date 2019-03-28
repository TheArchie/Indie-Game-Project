using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchingWeapons : MonoBehaviour {

    public int weaponChoice = 0;

	// Use this for initialization
	void Start ()
    {
        SelectWeapon();
	}

    // Change between weapons using the Scroll Wheel and the Numbers
    void Update()
    {
        int previousweaponChoice = weaponChoice;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (weaponChoice >= transform.childCount - 1)
                weaponChoice = 0;
            else
                weaponChoice++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (weaponChoice <= 0)
                weaponChoice = transform.childCount - 1;
            else
                weaponChoice--;
        }

        if(Input.GetKeyDown(KeyCode.Alpha1) && transform.childCount >=1)
        {
            weaponChoice = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            weaponChoice = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            weaponChoice = 2;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4)
        {
            weaponChoice = 3;
        }

        if (previousweaponChoice != weaponChoice)
        {
            SelectWeapon();
        }
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == weaponChoice)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}
