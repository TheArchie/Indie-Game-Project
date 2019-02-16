using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    public float enemyLevel;

    public float health;

    public float enemyDamage = 25f;

    public float xpReward = 75f;

    [SerializeField]
    private PlayerAttributes player;

    // Use this for initialization
    void Start()
    {
        //player = GetComponent<PlayerAttributes>();
        player.GetComponent<PlayerAttributes>();

        enemyLevel = Random.Range(1, 4);
    }

    // Update is called once per frame
    void Update()
    {
        EnemyLevels();
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

    void EnemyLevels()
    {
        if(enemyLevel <= 2)
        {
            health = 100f;
        }else if(enemyLevel >= 2 || enemyLevel <= 4 )
        {
            health = 120f;
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
}
