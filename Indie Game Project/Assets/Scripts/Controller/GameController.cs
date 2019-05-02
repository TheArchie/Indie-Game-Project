using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject hand;
    //public Camera deathCam;

    public bool cursorLock;

    private PlayerAttributes player;
    private UI uiController;

    // Use this for initialization
    void Start ()
    {
        //hand.SetActive(false);
        //deathCam.enabled = false;
        LockMouse();
        FindObjectOfType<AudioManager>().Play("MainTheme");
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void LockMouse()
    {
        if (cursorLock == true)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if (cursorLock == false)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

    }
}
