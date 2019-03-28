using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour {

    [SerializeField]
    private float meleeDamage;
    public float meleeBaseDamage;
    public float punchRate;
    private float punchTime;
    public float distance;
    private bool isPunching = false;

    public Camera cam;
    public Animator animator;

    public PlayerAttributes playerAttributes;

    // Use this for initialization
    void Start ()
    {
        playerAttributes.GetComponent<PlayerAttributes>();
    }

    private void OnEnable()
    {
        isPunching = false;
        animator.SetBool("isPunching", false);       
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetButton("Fire1") && Time.time >= punchTime) //Firing the gun
        {
            punchTime = Time.time + 1f / punchRate;
            Punch();
            Debug.Log("Punched");
        }
        CalculateWeaponDamage();

        if(Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(Punching());
            animator.SetBool("isPunching", false);
        }
    }

    void Punch()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hitInfo, distance))
        {
            Target target = hitInfo.transform.GetComponent<Target>();
            if (target != null)
            {
                target.Damage(meleeDamage);
            }
            StartCoroutine(Punching());
        }
    }

    IEnumerator Punching()
    {
        yield return new WaitForSeconds(0f);
        isPunching = true;
        animator.SetBool("isPunching", true);
        //animator.SetBool("isPunching", false);
    }

    void CalculateWeaponDamage()
    {
        var calculation = playerAttributes.playerSkills.currentMelee * 0.5f + 50;
        var calculation2 = calculation / 100;
        meleeDamage = Mathf.Round(meleeBaseDamage * calculation2);
    }
}
