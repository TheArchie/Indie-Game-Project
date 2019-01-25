﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public float weaponDamage = 30f; //Amount of damage the weapon does
    public int maxAmmo = 60; //Maximum ammo of the gun
    public int magazineAmmo = 20; //Maximum ammo of the magazine
   [SerializeField]
    private int currentAmmo; //the guns current ammo
    public float fireRate = 10f; //firerate of the gun
    public float weaponSpread = 1f; //spread of the weapon
    public float weaponRecoil = 1f; //recoil of the weapon
    public float reloadTime = 1.5f; //time it takes to reload
    private bool isReloading = false; //is the gun reloading 

    private float fireTime = 0f; //

    public Camera cam; //camera variable

    public Animator animator; //animator variable for reload animation

    public ParticleSystem muzzleFlash; //partical system variable for muzzle flash
    public GameObject impactEffect; //Impact effect Partical System


    public GameObject bulletDecal; //bullet holes variable

    //When the scene starts make current ammo equal to the magazine ammo
    void Start()
    {
        currentAmmo = magazineAmmo;
      
    }

    //When the scene enables, set the reload bool to false
    void OnEnable()
    {
        isReloading = false;
        animator.SetBool("isReloading", false);       
    }

    void Update()
    {
        if (isReloading)
            return;

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButton("Fire1") && Time.time >= fireTime) //Firing the gun
        {
            fireTime = Time.time + 1f / fireRate;
            Shoot();
            Debug.Log("Gun Fired");
        }

        Destroy(GameObject.FindWithTag("BulletDecal"),2f); //Destroy bullet decals after 2 seconds
    }

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Relaod");
        animator.SetBool("isReloading", true);

        yield return new WaitForSeconds(reloadTime - .25f);
        animator.SetBool("isReloading", false);
        yield return new WaitForSeconds(.25f);

        int bulletstoload = magazineAmmo - currentAmmo;
        int bulletoremove = (maxAmmo >= bulletstoload) ? bulletstoload : maxAmmo;
        maxAmmo -= bulletoremove;
        currentAmmo += bulletoremove;

        isReloading = false;
    }

    //Shoot function that plays a muzzle flash 
    void Shoot()
    {
        muzzleFlash.Play();
        currentAmmo--;
        RaycastHit hitInfo;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hitInfo));
        {
            Debug.Log(hitInfo.transform.name);
            Debug.Log(currentAmmo);

            Target target = hitInfo.transform.GetComponent<Target>();
            if(target != null)
            {
                target.Damage(weaponDamage);
            }
            Instantiate(impactEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));

            SpawnDecal(hitInfo);
        }
    }

    //Function for spawning the decals
    void SpawnDecal(RaycastHit hitInfo)
    {
        var decal = Instantiate(bulletDecal);
        decal.transform.position = hitInfo.point;
        decal.transform.forward = hitInfo.normal * -1f;
    }
}
