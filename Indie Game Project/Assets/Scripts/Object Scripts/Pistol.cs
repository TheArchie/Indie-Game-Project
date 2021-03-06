﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Pistol : MonoBehaviour {

    private int currentBulletCount;

    [SerializeField]
    private float weaponDamage; //Amount of damage the weapon does
    public float weaponBaseDamage;
    public int pistolMaxAmmo = 120; //Maximum ammo of the gun
    public int pistolMagazineAmmo = 12; //Maximum ammo of the magazine
    public int pistolCurrentAmmo; //the guns current ammo
    public float fireRate = 3f; //firerate of the gun
    public float weaponRecoil = 0.02f; //recoil of the weapon
    public float reloadTime = 1f; //time it takes to reload
    private bool isReloading = false; //is the gun reloading 
    [SerializeField]
    private bool pistolFired = false;

    private float fireTime = 0f; //How quickly the gun can be fired

    public Camera cam; //camera variable

    public Animator animator; //animator variable for reload animation

    public ParticleSystem muzzleFlash; //partical system variable for muzzle flash
    public GameObject impactEffect; //Impact effect Partical System
    public GameObject bulletDecal; //bullet holes variable
    public GameObject bloodEffect; //bullet holes variable

    public PlayerAttributes playerAttributes;

    public GameObject pistolCanvas;
    public TextMeshProUGUI ammoText;

    //When the scene starts make current ammo equal to the magazine ammo
    void Start()
    {
        pistolCurrentAmmo = pistolMagazineAmmo;
        playerAttributes.GetComponent<PlayerAttributes>();
    }

    //When the scene enables, set the reload bool to false
    void OnEnable()
    {
        isReloading = false;
        animator.SetBool("isReloading", false);
        pistolFired = false;
        animator.SetBool("pistolFired", false);
    }

    void Update()
    {
        if (isReloading)
            return;

        if (pistolCurrentAmmo <= 0 && pistolMaxAmmo >= 1)
        {
            StartCoroutine(Reload());
            // When reloading, we reset the current bullet count
            currentBulletCount = 0;
            return;
        }
        else if (pistolCurrentAmmo <= 0 && pistolMaxAmmo <= 0)
        {
            currentBulletCount = 0;
            animator.SetBool("pistolFired", false);
            pistolFired = false;
            return;
        }

        if (Input.GetButtonDown("Fire1") && Time.time >= fireTime) //Firing the gun
        {
            fireTime = Time.time + 1f / fireRate;
            Shoot();
            currentBulletCount++; //we add 1 to the current bullet count, which will increase the range for the spray
            Debug.Log("Gun Fired");
            pistolFired = true;
        }

        //if the player stop clicking, we reset the current bullet count
        if (Input.GetButtonUp("Fire1"))
        {
            pistolFired = false;
        }
            currentBulletCount = 0;

        ManualReload();
        UpdateAmmo();
        CalculateWeaponDamage();
    }

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Relaod");
        animator.SetBool("isReloading", true);
        animator.SetBool("pistolFired", false);

        yield return new WaitForSeconds(reloadTime - .25f);
        animator.SetBool("isReloading", false);
        yield return new WaitForSeconds(.25f);

        int bulletstoload = pistolMagazineAmmo - pistolCurrentAmmo;
        int bulletoremove = (pistolMaxAmmo >= bulletstoload) ? bulletstoload : pistolMaxAmmo;
        pistolMaxAmmo -= bulletoremove;
        pistolCurrentAmmo += bulletoremove;

        isReloading = false;
        pistolFired = false;
    }

    IEnumerator Shooting()
    {
        pistolFired = true;
        animator.SetBool("pistolFired", true);
        yield return new WaitForSeconds(0f);
        animator.SetBool("pistolFired", false);
    }

    Vector3 RandomizeSpray(Vector3 currentDir)
    {
        float r = currentBulletCount * weaponRecoil; //Increase the spray size depending on the current count of bullet fired
        return new Vector3(currentDir.x + Random.Range(0, r), currentDir.y + Random.Range(0, r), currentDir.z);
    }

    //Shoot function that plays a muzzle flash 
    void Shoot()
    {
        muzzleFlash.Play();
        pistolCurrentAmmo--;
        RaycastHit hitInfo;
        if (Physics.Raycast(cam.transform.position, RandomizeSpray(cam.transform.forward), out hitInfo))
        {
            Debug.Log(hitInfo.transform.name);
            Debug.Log(pistolCurrentAmmo);

            Target target = hitInfo.transform.GetComponent<Target>();
            if (target != null)
            {
                target.Damage(weaponDamage);
            }

            VentGrill ventGrill = hitInfo.transform.GetComponent<VentGrill>();
            if (ventGrill != null)
            {
                ventGrill.Damage(weaponDamage);
            }

            if (hitInfo.transform.gameObject.tag != "Enemy")
            {
                GameObject impacteffectGO = Instantiate(impactEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                Destroy(impacteffectGO, 1.5f);
            }

            if (hitInfo.transform.gameObject.tag == "Enemy")
            {
                GameObject bloodeffectGo = Instantiate(bloodEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                Destroy(bloodeffectGo, 1.5f);
            }

            SpawnDecal(hitInfo);
            StartCoroutine(Shooting());
            FindObjectOfType<AudioManager>().Play("Pistol");
        }
    }

    //Function for spawning the decals and destroying them 
    void SpawnDecal(RaycastHit hitInfo)
    {
        if (hitInfo.transform.gameObject.tag != "Enemy")
        {
            var decal = Instantiate(bulletDecal);
            decal.transform.position = hitInfo.point;
            decal.transform.forward = hitInfo.normal * -1f;
            Destroy(decal, 2f);
            decal.transform.parent = hitInfo.transform;
        }
    }

    void ManualReload()
    {
        if (Input.GetButtonDown("Reload"))
        {
            StartCoroutine(Reload());
        }
    }

    void CalculateWeaponDamage()
    {
        var calculation = playerAttributes.playerSkills.currentRifles * 0.5f + 50;
        var calculation2 = calculation / 100;
        weaponDamage = Mathf.Round(weaponBaseDamage * calculation2);
    }

    void UpdateAmmo()
    {
        ammoText.text = pistolCurrentAmmo + " / " + pistolMaxAmmo;
    }
}
