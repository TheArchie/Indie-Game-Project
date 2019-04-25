using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Raycast : MonoBehaviour
{

    public Camera cam;
    public RaycastHit hitInfo;

    public TextMeshProUGUI enemyText;

    //public Target enemy;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastForEnemyDetection();
    }

    void RaycastForEnemyDetection()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hitInfo))
        {
            DetectEnemy();
        }
    }

    void DetectEnemy()
    {
        if(hitInfo.transform.gameObject.tag == "Enemy")
        {
            enemyText.enabled = true;
            enemyText.text = hitInfo.transform.gameObject.name;
            enemyText.color = Color.red;
        }else
        {
            if(hitInfo.transform.gameObject.tag != "Enemy")
            {
                enemyText.enabled = false;
            }
        }
    }
}
