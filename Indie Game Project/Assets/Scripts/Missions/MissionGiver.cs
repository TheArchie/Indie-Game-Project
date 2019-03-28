using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MissionGivers : MonoBehaviour {

    public Mission mission;
    public UI ui;

    public PlayerAttributes playerAtts;
    public GameObject missionWindow;

    public bool missionWindowActive;

    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI rewardText;

    public void Start()
    {
        missionWindowActive = false;
    }

    public void ShowUI()
    {
        missionWindow.SetActive(true);
        missionWindowActive = true;

        titleText.text = mission.missionTitle;
        descriptionText.text = mission.missionDescription;
        rewardText.text = mission.expReward.ToString();
        ui.PauseGame();
    }

    public void HideUI()
    {
        missionWindow.SetActive(false);
        missionWindowActive = false;
    }

    public void AcceptQuest()
    {
        missionWindow.SetActive(false);
        missionWindowActive = false;
        mission.isActive = true;
        //playerAtts.mission = mission;
        playerAtts.missions.Add(mission);
        ui.UnPauseGame();
        Debug.Log("Mission is Active");
    }

    public void DeclineQuest()
    {
        missionWindow.SetActive(false);
        missionWindowActive = false;
        mission.isActive = false;
        ui.UnPauseGame();
    }
}
