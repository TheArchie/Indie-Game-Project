using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mission {

    public bool isActive;

    public string missionTitle;
    public string missionDescription;
    public float expReward;
    public float otherReward;

    public MissionGoal missionGoal;

    public void Complete()
    {
        isActive = false;
        Debug.Log(missionTitle + "was completed");
    }
}
