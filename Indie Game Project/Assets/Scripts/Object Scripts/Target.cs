using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    public enum EnemyClass
    {
        verySmall, Small, Medium, Big, veryBig
    }

    public EnemyClass enemyClasses;

    public float enemyLevel;
    public float health;
    public int endurance;
    public float enemyDamage;
    public float baseenemyDamage;
    public float xpReward;
    public bool elite;

    public string enemyName;

    public int ID { get; set; }

    public float damageTimer;

    [SerializeField]
    private PlayerAttributes player;

    public UI uiController;

    Renderer objRenderer;
    CapsuleCollider capColl;

    GameObject obj;

    Coroutine farts;


    // Use this for initialization
    void Start()
    {
        //player = GetComponent<PlayerAttributes>();
        player.GetComponent<PlayerAttributes>();

        enemyLevel = Random.Range(1, 4);
        SettingVariables();
        EnemyHealth();
        ID = 0;

        enemyName = this.gameObject.name;

        CalculateEnemyDamage();

        uiController.GetComponent<UI>();
        //objRenderer = GetComponent<Renderer>();
        //capColl = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Damage(float amountofDamage)
    {
        health -= amountofDamage;
        if (health <= 0)
        {
            player.playerAtts.currentXp += xpReward;
            Death();
        }
    }

    void Death()
    {
        StartCoroutine(AddedXP());
        //StartCoroutine(KillEnemy());
        Destroy(transform.parent.gameObject);
    }

    void EnemyHealth()
    {
        var calculation = (endurance * 20) + (enemyLevel * 10);
        var calculation2 = 90 + calculation;
        health = calculation2;
        if(elite == true)
        {
            health = calculation2 * 2;
        }
    }

    void CalculateEnemyDamage()
    {
        var calculation = endurance * enemyLevel + 50;
        var calculation2 = calculation / 100;
        enemyDamage = Mathf.Round(calculation2 * baseenemyDamage);
    }

    void OnCollisionEnter(Collision collision)
    {
        PlayerAttributes player = collision.collider.GetComponent<PlayerAttributes>();
        if(player != null)
        {
           player.DamagePlayer(enemyDamage);
           Debug.Log("Player Health is " + player.playerInfo.currentHealth);
           //damageTimer += Time.deltaTime;
           //Debug.Log(damageTimer);
        } 
    }

    private void OnTriggerStay(Collider other)
    {
        if(player != null)
        {

        }
    }

    void SettingVariables()
    {
        if(enemyClasses == EnemyClass.verySmall)
        {
            endurance = Random.Range(1, 3);
            xpReward = 10f;
            baseenemyDamage = 10;
        }

        if (enemyClasses == EnemyClass.Small)
        {
            endurance = Random.Range(3, 5);
            xpReward = 20f;
            baseenemyDamage = 20;
        }

        if (enemyClasses == EnemyClass.Medium)
        {
            endurance = Random.Range(5, 7);
            xpReward = 30f;
            baseenemyDamage = 30;
        }

        if (enemyClasses == EnemyClass.Big)
        {
            endurance = Random.Range(7, 9);
            xpReward = 40f;
            baseenemyDamage = 40;
        }

        if (enemyClasses == EnemyClass.veryBig)
        {
            endurance = Random.Range(9, 11);
            xpReward = 50f;
            baseenemyDamage = 50;
        }

        if(elite == true)
        {
            xpReward = xpReward * 10;
            enemyDamage = enemyDamage * 2;
        }
    }

    IEnumerator AddedXP()
    {
        uiController.addedXPText.enabled = true;
        uiController.addedXPText.text = "+" + xpReward.ToString() + "XP";
        yield return new WaitForSeconds(2f);
        //uiController.addedXPText.enabled = false;
    }

    IEnumerator KillEnemy()
    {
        //objRenderer.enabled = false;
        //capColl.enabled = false;
        yield return new WaitForSeconds(2.1f);
        //Destroy(gameObject);
        Destroy(transform.parent.gameObject);
    }
}
