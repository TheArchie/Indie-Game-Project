using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    public float health = 100f;

    public float enemyDamage = 25f;

    public float xpReward = 75f;

    [SerializeField]
    private PlayerAttributes player;

    // Use this for initialization
    void Start()
    {
        //player = GetComponent<PlayerAttributes>();
        player.GetComponent<PlayerAttributes>();
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
