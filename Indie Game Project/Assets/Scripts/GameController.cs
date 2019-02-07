using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject hand;
    public Camera deathCam;

    //public PlayerAttributes playeratts;



	// Use this for initialization
	void Start ()
    {
        //hand.SetActive(false);
        deathCam.enabled = false;

        //playeratts = GetComponent<PlayerAttributes>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
