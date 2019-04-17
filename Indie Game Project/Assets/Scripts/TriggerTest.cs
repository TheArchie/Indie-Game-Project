using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTest : MonoBehaviour {

    [SerializeField]
    PlayerAttributes playerAttributes;
    public float xpReward = 150f;

	// Use this for initialization
	void Start ()
    {
        playerAttributes.GetComponent<PlayerAttributes>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("In Trigger");
            playerAttributes.playerAtts.currentXp += xpReward;
            Debug.Log("Player Has Gained " + xpReward + "XP");

            Destroy(gameObject);
        }
    }
}
