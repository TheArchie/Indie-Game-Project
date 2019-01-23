using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public float weaponDamage = 30f; 

    public Camera cam;

    public ParticleSystem muzzleFlash;

     void Start()
    {
      
    }

    // Update is called once per frame
    void Update ()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }		
	}

    void Shoot()
    {
        muzzleFlash.Play();
        RaycastHit hitInfo;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hitInfo));
        {
            Debug.Log(hitInfo.transform.name);

            Target target = hitInfo.transform.GetComponent<Target>();
            if(target != null)
            {
                target.Damage(weaponDamage);
            }
        }
    }
}
