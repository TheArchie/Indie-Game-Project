using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTest : MonoBehaviour {

    [SerializeField]
    PlayerAttributes playerAttributes;
    [SerializeField]
    private UI uiController;

    public float xpReward = 150f;

    public string objective;

	// Use this for initialization
	void Start ()
    {
        playerAttributes.GetComponent<PlayerAttributes>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("In Trigger");
            playerAttributes.playerAtts.currentXp += xpReward;
            Debug.Log("Player Has Gained " + xpReward + "XP");

            StartCoroutine(AddText());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    IEnumerator AddText()
    {
        uiController.objectiveText.enabled = true;
        uiController.objectiveText.text = objective;
        yield return new WaitForSeconds(0.1f);
        uiController.objectiveText.enabled = false;
    }
}
