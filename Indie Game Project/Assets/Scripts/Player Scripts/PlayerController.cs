using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //Player Movement Variables
    public float playerSpeed = 3.5f;
    public float jumpForce = 40.0f;
    public bool isCrouching;

    //Player Crouch Vars
    private float crouchHeight = 0.1f;
    private float standHeight = 2.5f;

    //Mouse Look Variables
    public float Ysensitivity = 1f;
    public float Xsensitivity = 1f;
    public float yMin = -70f;
    public float yMax = 90f;
    public float mouseDirection;

    //Stamina Variables
    public float staminalossRate = 1f;
    public float staminagainRate = 10f;
    public bool increaseStamina;
    public bool staminaGone;

    PlayerAttributes playerInfo;
    private PlayerAttributes stamina;

    [SerializeField]
    private Rigidbody rgb;

    [SerializeField]
    private CapsuleCollider capCollider;

    public Transform cam;

    public bool cursorLock;

    public HeadBobbing headbob;

    void Start()
    {
        rgb = GetComponent<Rigidbody>();
        capCollider = GetComponent<CapsuleCollider>();
        //LockMouse();
        headbob.GetComponent<HeadBobbing>();
        playerInfo = GetComponent<PlayerAttributes>();
        increaseStamina = true;
        StartCoroutine("UpdateStamina");
        isCrouching = false;
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Movement();
        //Interact();
        Crouch();
    }

    private void FixedUpdate()
    {
        //Movement();
        MouseLook();
    }

    void Movement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * Time.deltaTime * playerSpeed;
        float moveVertical = Input.GetAxis("Vertical") * Time.deltaTime * playerSpeed;

        transform.Translate(moveHorizontal, 0, moveVertical);

        if(Input.GetButtonDown("Sprint"))
        {
            playerSpeed = 7.0f;
            increaseStamina = false;
            Debug.Log("Sprint");
            headbob.bobbingAmount = 0.08f;
            headbob.bobbingSpeed = 0.2f;
            if(isCrouching == true)
            {
                playerSpeed = 1.5f;
                headbob.bobbingAmount = 0.03f;
                headbob.bobbingSpeed = 0.1f;
            }
        }else if(Input.GetButtonUp("Sprint")) 
        {
            playerSpeed = 3.5f;
            increaseStamina = true;
            Debug.Log("Normal");
            headbob.bobbingAmount = 0.05f;
            headbob.bobbingSpeed = 0.18f;
            if (isCrouching == true)
            {
                playerSpeed = 1f;
                headbob.bobbingAmount = 0.01f;
                headbob.bobbingSpeed = 0.05f;
            }
        }

        if(playerInfo.playerInfo.currentStamina <= 0)
        {
            staminaGone = true;
            increaseStamina = true;
            playerSpeed = 3.5f;
        }
        

        //Alternative Player Movement

        /*float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;
        rgb.velocity = movement * playerSpeed;*/
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && rgb.velocity == Vector3.zero)
        {
            rgb.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.Impulse);
            Debug.Log("Player Jumped");
        }
    }

    void Crouch()
    {
        Debug.DrawRay(transform.position, Vector3.up * 1f, Color.red);

        if (Input.GetButtonDown("Crouch") && !isCrouching) //If the crouch button is pressed and the player is not coruching then crouch
        {
            isCrouching = true;
            capCollider.height = crouchHeight;
            playerSpeed = 1f;
            headbob.bobbingAmount = 0.01f;
            headbob.bobbingSpeed = 0.05f;
        }
        else if(Input.GetButtonDown("Crouch") && isCrouching) //if the button is pressed and the player is crouching then stand
        {
            var cantStand = Physics.Raycast(transform.position, Vector3.up, 1f);
            if(!cantStand)
            {
                isCrouching = false;
                capCollider.height = standHeight;
                playerSpeed = 3.5f;
                headbob.bobbingAmount = 0.05f;
                headbob.bobbingSpeed = 0.18f;
            }
        }

    }

    void MouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * Xsensitivity;
        mouseDirection -= Input.GetAxis("Mouse Y") * Ysensitivity;
        mouseDirection = Mathf.Clamp(mouseDirection, yMin, yMax);

        transform.Rotate(0, mouseX, 0);
        Quaternion fpsCam = Quaternion.Euler(mouseDirection, 0, 0);
        cam.localRotation = fpsCam;
    }

    /*void LockMouse()
    {
        if(cursorLock == true)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }else if(cursorLock == false)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
       
    }*/

    IEnumerator UpdateStamina()
    {
        Debug.Log(increaseStamina);
        while (true)
        {
            if(increaseStamina)
            {
                playerInfo.staminaGain(staminagainRate);
                yield return new WaitForSeconds(1f);
            }else
            {
                playerInfo.staminaLoss(staminalossRate);
                yield return new WaitForSeconds(0.1f);
            }
            //yield return new WaitForSeconds(0.1f);
        }
    }

    /*void Interact()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hitInfo))
        {
            Debug.Log(hitInfo.transform.name);
        }
    }*/
}
