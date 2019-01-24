using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public float weaponDamage = 30f; //Amount of damage the weapon does
    public int maxAmmo = 60;
    public int magazineAmmo = 20;
   [SerializeField]
    private int currentAmmo;
    public float fireRate = 10f;
    public float weaponSpread = 1f;
    public float weaponRecoil = 1f; 
    public float reloadTime = 1.5f;
    private bool isReloading = false;

    private float fireTime = 0f;

    public Camera cam;

    public Animator animator;

    public ParticleSystem muzzleFlash;

    [SerializeField]
    private GameObject bulletDecal;

     void Start()
    {
        currentAmmo = magazineAmmo;
      
    }

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

        if (Input.GetButton("Fire1") && Time.time >= fireTime) 
        {
            fireTime = Time.time + 1f / fireRate;
            Shoot();
            Debug.Log("Gun Fired");
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
            SpawnDecal(hitInfo);
        }
    }

    void SpawnDecal(RaycastHit hitInfo)
    {
        var decal = Instantiate(bulletDecal);
        decal.transform.position = hitInfo.point;
        decal.transform.forward = hitInfo.normal * -1f;
    }
}
