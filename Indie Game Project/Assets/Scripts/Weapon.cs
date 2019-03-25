using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    private int currentBulletCount;

    [SerializeField]
    private float weaponDamage; //Amount of damage the weapon does
    public float weaponBaseDamage;
    public int maxAmmo = 60; //Maximum ammo of the gun
    public int magazineAmmo = 20; //Maximum ammo of the magazine
    public int currentAmmo; //the guns current ammo
    public float fireRate = 10f; //firerate of the gun
    public float weaponRecoil = 0.05f; //recoil of the weapon
    public float recoilAmount = 0f;
    public float reloadTime = 1.5f; //time it takes to reload
    private bool isReloading = false; //is the gun reloading 
    private bool isShooting = false;

    private float fireTime = 0f; //How quickly the gun can be fired

    public Camera cam; //camera variable

    public Animator animator; //animator variable for reload animation

    public ParticleSystem muzzleFlash; //partical system variable for muzzle flash
    public GameObject impactEffect; //Impact effect Partical System
    public GameObject bulletDecal; //bullet holes variable

    public PlayerAttributes playerAttributes;
    public UI ui;

    [SerializeField]
    private Animator anim;

    //When the scene starts make current ammo equal to the magazine ammo
    void Start()
    {
        currentAmmo = magazineAmmo;
        playerAttributes.GetComponent<PlayerAttributes>();
        anim = GetComponent<Animator>();
    }

    //When the scene enables, set the reload bool to false
    void OnEnable()
    {
        isReloading = false;
        animator.SetBool("isReloading", false);
        isShooting = false;
        animator.SetBool("isShooting", false);
    }

    void Update()
    {
        if (isReloading)
            return;

        if (currentAmmo <= 0 && maxAmmo >= 1)
        {
            StartCoroutine(Reload());
            // When reloading, we reset the current bullet count
            currentBulletCount = 0;
            return;
        }
        else if (currentAmmo <= 0 && maxAmmo <= 0)
        {
            currentBulletCount = 0;
            return;
        }

        if (Input.GetButton("Fire1") && Time.time >= fireTime) //Firing the gun
        {
            fireTime = Time.time + 1f / fireRate;
            Shoot();
            currentBulletCount++; //we add 1 to the current bullet count, which will increase the range for the spray
            Debug.Log("Gun Fired");
            Debug.Log("Bullet Count is " + currentBulletCount);
        }

        //if the player stop clicking, we reset the current bullet count
        if (Input.GetButtonUp("Fire1"))
        {
            StartCoroutine(RecoilCount());
            StopCoroutine(Shooting());
            animator.SetBool("isShooting", false);
        }

        ManualReload();

        CalculateWeaponDamage();

        if(Input.GetKeyDown(KeyCode.O))
        {
            Debug.Log("Weapon Damage is " + weaponDamage);
        }
    }

    IEnumerator RecoilCount()
    {
        yield return new WaitForSeconds(1f);
        //currentBulletCount--;
        currentBulletCount = 0;
        if(currentBulletCount <= 0)
        {
            currentBulletCount = 0;
        }
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

    IEnumerator Shooting()
    {
        isShooting = true;
        animator.SetBool("isShooting", true);
        yield return new WaitForSeconds(0f);
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
        currentAmmo--;
        RaycastHit hitInfo;
        if (Physics.Raycast(cam.transform.position, RandomizeSpray(cam.transform.forward), out hitInfo))
        {
            Debug.Log(hitInfo.transform.name);
            Debug.Log(currentAmmo);

            Target target = hitInfo.transform.GetComponent<Target>();
            if (target != null)
            {
                target.Damage(weaponDamage);
            }
            GameObject impacteffectGO = Instantiate(impactEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            Destroy(impacteffectGO, 1.5f);

            SpawnDecal(hitInfo);
            StartCoroutine(Shooting());
        }
    }

    //Function for spawning the decals and destroying them 
    void SpawnDecal(RaycastHit hitInfo)
    {
        var decal = Instantiate(bulletDecal);
        decal.transform.position = hitInfo.point;
        decal.transform.forward = hitInfo.normal * -1f;
        Destroy(decal, 2f);
        decal.transform.parent = hitInfo.transform;
    }

    void ManualReload()
    {
        if(Input.GetButtonDown("Reload"))
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
}
