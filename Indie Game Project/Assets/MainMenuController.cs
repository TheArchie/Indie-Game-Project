using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

    public GameObject mainmenu;
    public GameObject optionsMenu;
    public GameObject quitPrompt;

    public GameObject cutscence1;
    public GameObject cutscence2;

    public GameObject fade;

    public TextMeshProUGUI titleText;

    public Animator anim;


    // Use this for initialization
    void Start ()
    {
        mainmenu.SetActive(true);
        optionsMenu.SetActive(false);
        quitPrompt.SetActive(false);

        cutscence1.SetActive(false);
        cutscence2.SetActive(false);

        titleText.enabled = true;

        fade.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void PlayButton()
    {
        //SceneManager.LoadScene("Main");
        cutscence1.SetActive(true);
        mainmenu.SetActive(false);
        titleText.enabled = false;

        fade.SetActive(true);

        anim.SetTrigger("fadeOut");

        StartCoroutine(ChangeCutscence());
    }

    public void FadeIn()
    {
        fade.SetActive(false);
        cutscence1.SetActive(true);
    }

    IEnumerator ChangeCutscence()
    {
        yield return new WaitForSeconds(1f);
        cutscence1.SetActive(false);
        cutscence2.SetActive(true);
    }
}
