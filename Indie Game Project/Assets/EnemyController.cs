﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

    public float lookRadius;
    public float persuitlookRadius;
    public float retreatDistance;
    Transform target;
    NavMeshAgent agent;

    public EnemyPatrol enemyPatrol;
    public Target enemyTarget;


	// Use this for initialization
	void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
        target = PlayerManager.instance.player.transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
        EnemyChase();
	}

    public void EnemyChase()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            lookRadius = persuitlookRadius;
            Debug.Log("Distance is " + distance);

            if (distance <= agent.stoppingDistance)
            {
                LookAtTarget();
            }
        }
        else
        {
            lookRadius = 2;
        }
    }

    void LookAtTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}