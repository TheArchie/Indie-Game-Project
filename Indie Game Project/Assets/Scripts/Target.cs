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
    public float enemyDamage = 25f;
    public float xpReward;
    public bool elite; 

    public int ID { get; set; }

    [SerializeField]
    private PlayerAttributes player;

    // Use this for initialization
    void Start()
    {
        //player = GetComponent<PlayerAttributes>();
        player.GetComponent<PlayerAttributes>();

        enemyLevel = Random.Range(1, 4);
        SettingVariables();
        EnemyHealth();
        ID = 0;
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
        Destroy(gameObject);
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

    void OnCollisionEnter(Collision collision)
    {
        PlayerAttributes player = collision.collider.GetComponent<PlayerAttributes>();
        if(player != null)
        {
           player.DamagePlayer(enemyDamage);
            Debug.Log("Player Health is " + player.playerInfo.currentHealth);
        } 
    }

    void SettingVariables()
    {
        if(enemyClasses == EnemyClass.verySmall)
        {
            endurance = Random.Range(1, 3);
            xpReward = 10f;
        }

        if (enemyClasses == EnemyClass.Small)
        {
            endurance = Random.Range(3, 5);
            xpReward = 20f;
        }

        if (enemyClasses == EnemyClass.Medium)
        {
            endurance = Random.Range(5, 7);
            xpReward = 30f;
        }

        if (enemyClasses == EnemyClass.Big)
        {
            endurance = Random.Range(7, 9);
            xpReward = 40f;
        }

        if (enemyClasses == EnemyClass.veryBig)
        {
            endurance = Random.Range(9, 11);
            xpReward = 50f;
        }

        if(elite == true)
        {
            xpReward = xpReward * 10;
            enemyDamage = enemyDamage * 2;
        }
    }
}
