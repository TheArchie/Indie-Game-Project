using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour {

    public float enemySpeed;

    public Transform[] moveSpots;
    private int randomSpot;

    private float waitTime;
    public float startWaitTime;

	// Use this for initialization
	void Start ()
    {
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);		
	}
	
	// Update is called once per frame
	void Update ()
    {
        EnemyPatrolling();
	}

    public void EnemyPatrolling()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveSpots[randomSpot].position, enemySpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
                LookAtTarget();
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    void LookAtTarget()
    {
        Vector3 direction = (moveSpots[randomSpot].position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
