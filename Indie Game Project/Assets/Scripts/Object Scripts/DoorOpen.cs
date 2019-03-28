using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour {

    public Animator animator;

    public bool doorOpen;
    public bool inTrigger;

	// Use this for initialization
	void Start ()
    {
        animator = GetComponent<Animator>();		
	}

    public void Awake()
    {
        doorOpen = false;
        inTrigger = false;
    }

    // Update is called once per frame
    void Update ()
    {
        OpenDoor();		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            inTrigger = true;
            Debug.Log("In Trigger");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            inTrigger = false;
            Debug.Log("Out of Trigger");
        }       
    }

    public void OpenDoor()
    {
        if(inTrigger == true)
        {
            if(Input.GetButtonDown("Interact") && doorOpen == false)
            {
                animator.SetBool("Open", true);
                doorOpen = true;
            }
        }else if(Input.GetButtonDown("Interact") && doorOpen == true)
        {
            animator.SetBool("Open", false);
            doorOpen = false;
        }
    }
}
