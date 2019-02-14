using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour {

    public Transform hand2;
    public bool isHolding;

	// Use this for initialization
	void Start ()
    {
        isHolding = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //PickUp();	
	}

    /*void PickUp()
    {
        if(Input.GetButtonDown("Interact"))
        {
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<Rigidbody>().useGravity = false;
            this.transform.position = hand2.position;
            this.transform.parent = GameObject.Find("Hand_2").transform;
        }else if(Input.GetButtonUp("Interact"))
        {
            this.transform.parent = null;
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<BoxCollider>().enabled = true;
        }
    }*/

    void OnMouseOver()
    {
        if(Input.GetButton("Interact"))
        {
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<Rigidbody>().useGravity = false;
            this.transform.position = hand2.position;
            this.transform.parent = GameObject.Find("Hand_2").transform;
            isHolding = true;
        }else if (Input.GetButtonUp("Interact"))
        {
            gameObject.transform.parent = null;
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<BoxCollider>().enabled = true;
            isHolding = false;
        }
    }

    /*void OnMouseExit()
    {
        if(Input.GetButtonUp("Interact"))
        {
            this.transform.parent = null;
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<BoxCollider>().enabled = true;
        }
    }*/
}
