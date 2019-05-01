using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Raycast : MonoBehaviour
{

    public Camera cam;
    public RaycastHit hitInfo;
    public float distance = 3;

    public TextMeshProUGUI enemyText;

    public Target enemy;

    //public Target enemy;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastForEnemyDetection();
        RaycastForEnemy();
    }

    void RaycastForEnemyDetection()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hitInfo, distance))
        {
            //ItemPickUpPrompt();
        }
    }
    void RaycastForEnemy()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hitInfo))
        {
            DetectEnemy();
        }
    }

    /*void ItemPickUpPrompt()
    {
        if(hitInfo.transform.gameObject.tag == "Weapon")
        {
            enemyText.enabled = true;
            enemyText.text = "Press E to Pickup " + hitInfo.transform.gameObject.name;
            enemyText.color = Color.white;
        }

        if(hitInfo.transform.gameObject.tag == "Computer")
        {
            enemyText.enabled = true;
            enemyText.text = "Required Sciecne 25";
            enemyText.color = Color.green;
        }

        if (hitInfo.transform.gameObject.tag == "RepairPart")
        {
            enemyText.enabled = true;
            enemyText.text = "Press E to Pickup " + hitInfo.transform.gameObject.name;
            enemyText.color = Color.white;
        }
    }*/

    void DetectEnemy()
    {
        if(hitInfo.transform.gameObject.tag == "Enemy")
        {
            enemyText.enabled = true;
            enemyText.text = hitInfo.transform.gameObject.name;
            enemyText.color = Color.red;
        }else if(hitInfo.transform.gameObject.tag != "Enemy")
        {
            enemyText.enabled = false;
        }
    }
}
