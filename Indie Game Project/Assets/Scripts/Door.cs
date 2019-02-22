using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public Animator anim;

	// Use this for initialization
	void Start ()
    {
        //anim.SetBool("doorOpening", false);	
        anim = GetComponent<Animator>();
	}

    private void Awake()
    {

    }

    // Update is called once per frame
    void Update ()
    {

	}

    private void OnEnable()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

    }

    private void OnTriggerExit(Collider other)
    {

    }
}
