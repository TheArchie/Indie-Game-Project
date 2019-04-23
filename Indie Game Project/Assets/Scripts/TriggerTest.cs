using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTest : MonoBehaviour {

    [SerializeField]
    PlayerAttributes playerAttributes;
    [SerializeField]
    private UI uiController;

    public float xpReward = 150f;

    public string questTitle;
    public string questDescription;
    public string questsubOjective;
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
            StartCoroutine(AddedXP());      
            uiController.missionLogObjectiveText.text = questsubOjective;
            uiController.questTitleText.text = questTitle;
            uiController.questDescriptionText.text = questDescription;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            Destroy(gameObject, 2f);
        }
    }

    IEnumerator AddText()
    {
        uiController.objectiveText.enabled = true;
        uiController.objectiveText.text = objective;
        yield return new WaitForSeconds(2f);
        uiController.objectiveText.enabled = false;
    }

    IEnumerator AddedXP()
    {
        if(xpReward <= 0)
        {
            uiController.addedXPText.enabled = false;         
        }else
        {
            if(xpReward >= 1)
            {
                uiController.addedXPText.enabled = true;
                uiController.addedXPText.text = "+" + xpReward.ToString() + "XP";
                yield return new WaitForSeconds(2f);
                uiController.addedXPText.enabled = false;
            }
        }
    }
}
