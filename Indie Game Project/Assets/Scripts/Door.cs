using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public Animator anim;

    public bool isOpening;

	// Use this for initialization
	void Start ()
    {
        //anim.SetBool("doorOpening", false);	
        anim = GetComponent<Animator>();
	}

    private void OnEnable()
    {
        isOpening = false;
        anim.SetBool("doorOpen", false);
    }

    // Update is called once per frame
    void Update ()
    {

	}

    public IEnumerator OpenDoor()
    {
        isOpening = true;
        anim.SetBool("doorOpen", true);
        yield return new WaitForSeconds(0f);
        Debug.Log("Door is Opening");
    }

    public IEnumerator CloseDoor()
    {
        isOpening = false;
        anim.SetBool("doorOpen", false);
        yield return new WaitForSeconds(0f);
        Debug.Log("Door is Closing");
    }
}
