using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float playerSpeed = 5.0f;
    public float jumpForce = 40.0f;

    public float Ysensitivity = 1f;
    public float Xsensitivity = 1f;
    public float yMin = -45f;
    public float yMax = 45f;
    public float pitch;

    [SerializeField]
    private Rigidbody rgb;

    public Transform cam;

    public bool cursorLock; 

    void Start()
    {
        rgb = GetComponent<Rigidbody>();
        LockMouse();

    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Movement();
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

    void MouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * Xsensitivity;
        pitch -= Input.GetAxis("Mouse Y") * Ysensitivity;
        pitch = Mathf.Clamp(pitch, yMin, yMax);

        transform.Rotate(0, mouseX, 0);
        Quaternion fpsCam = Quaternion.Euler(pitch, 0, 0);
        cam.localRotation = fpsCam;
    }

    void LockMouse()
    {
        if(cursorLock = true)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
       
    }
}
