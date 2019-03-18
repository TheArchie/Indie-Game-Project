using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MissionGiver : MonoBehaviour {

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
        mission.isActive = true;
        playerAtts.mission = mission;
        ui.UnPauseGame();
    }

    public void DeclineQuest()
    {
        missionWindow.SetActive(false);
        mission.isActive = false;
        ui.UnPauseGame();
    }

}
