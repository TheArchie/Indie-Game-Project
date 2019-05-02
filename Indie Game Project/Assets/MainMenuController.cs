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

    public GameObject fade;

    public TextMeshProUGUI titleText;

    public GameObject text1;
    public GameObject text2;
    public GameObject text3;

    public Animator anim;


    // Use this for initialization
    void Start ()
    {
        mainmenu.SetActive(true);
        optionsMenu.SetActive(false);
        quitPrompt.SetActive(false);

        cutscence1.SetActive(false);

        titleText.enabled = true;

        fade.SetActive(false);

        FindObjectOfType<AudioManager>().Play("MainMenuTheme");
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void PlayButton()
    {
        //SceneManager.LoadScene("Main");
        //mainmenu.SetActive(false);
        //titleText.enabled = false;

        fade.SetActive(true);
        anim.SetTrigger("fadeOut");

        //StartCoroutine(ChangeCutscence());
    }

    public void OptionsButton()
    {
        mainmenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void OptionsReturn()
    {
        mainmenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void QuitButton()
    {
        mainmenu.SetActive(false);
        quitPrompt.SetActive(true);
    }

    public void QuitYes()
    {
        Application.Quit();
    }

    public void QuitNo()
    {
        mainmenu.SetActive(true);
        quitPrompt.SetActive(false);
    }

    public void ButtonHover()
    {
        FindObjectOfType<AudioManager>().Play("ButtonHover");
    }

    public void ButtonClick()
    {
        FindObjectOfType<AudioManager>().Play("ButtonClick");
    }

    public void FadeIn()
    {
        anim.SetTrigger("fadeIn");
        mainmenu.SetActive(false);
        titleText.enabled = false;
        cutscence1.SetActive(true);
        StartCoroutine(ChangeTexts());
    }

    IEnumerator ChangeTexts()
    {
        yield return new WaitForSeconds(0f);
        text1.SetActive(true);
        yield return new WaitForSeconds(15f);
        text1.SetActive(false);
        text2.SetActive(true);
        yield return new WaitForSeconds(15f);
        text2.SetActive(false);
        text3.SetActive(true);
        yield return new WaitForSeconds(10f);
        anim.SetTrigger("fadeOut");
        SceneManager.LoadScene("Main");
    }
}
