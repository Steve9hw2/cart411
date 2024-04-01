
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonUI : MonoBehaviour
{
    [SerializeField] private string mainGameScene = "Intro";
    [SerializeField] private string introScene = "Intro";

    public bool inOptions;

    private void Update()
    {
        GameObject menuBGLabel = GameObject.Find("MenuBG");
        Image menuBG = menuBGLabel.GetComponent<Image>();
        GameObject officeBGLabel = GameObject.Find("OfficeBG");
        Image officeBG = officeBGLabel.GetComponent<Image>();
        GameObject playButtonLabel = GameObject.Find("PlayButton");
        Image playButton = playButtonLabel.GetComponent<Image>();
        GameObject playTxtLabel = GameObject.Find("Play");
        TMP_Text playTxt = playTxtLabel.GetComponent<TMP_Text>();
        GameObject optionsButtonLabel = GameObject.Find("OptionsButton");
        Image optionsButton = optionsButtonLabel.GetComponent<Image>();
        GameObject optionsTxtLabel = GameObject.Find("Options");
        TMP_Text optionsTxt = optionsTxtLabel.GetComponent<TMP_Text>();
        GameObject exitButtonLabel = GameObject.Find("ExitButton");
        Image exitButton = exitButtonLabel.GetComponent<Image>();
        GameObject exitButtonTxt = GameObject.Find("Exit");
        TMP_Text exitTxt = exitButtonTxt.GetComponent<TMP_Text>();
        GameObject toggleMuteButtonLabel = GameObject.Find("ToggleMuteButton");
        Image toggleMuteButton = toggleMuteButtonLabel.GetComponent<Image>();
        GameObject toggleMuteTxtLabel = GameObject.Find("ToggleMute");
        TMP_Text toggleMuteTxt = toggleMuteTxtLabel.GetComponent<TMP_Text>();
        GameObject backButtonLabel = GameObject.Find("BackButton");
        Image backButton = backButtonLabel.GetComponent<Image>();
        GameObject backTxtLabel = GameObject.Find("Back");
        TMP_Text backTxt = backTxtLabel.GetComponent<TMP_Text>();

        switch (inOptions)
        {
            case false:
                menuBG.enabled = true;
                officeBG.enabled = false;
                playButton.enabled = true;
                playTxt.enabled = true;
                optionsButton.enabled = true;
                optionsTxt.enabled = true;
                exitButton.enabled = true;
                exitTxt.enabled = true;
                toggleMuteButton.enabled = false;
                toggleMuteTxt.enabled = false;
                backButton.enabled = false;
                backTxt.enabled = false;
                break;     
            case true:
                menuBG.enabled = false;
                officeBG.enabled = true;
                playButton.enabled = false;
                playTxt.enabled = false;
                optionsButton.enabled = false;
                optionsTxt.enabled = false;
                exitButton.enabled = false;
                exitTxt.enabled = false;
                toggleMuteButton.enabled = true;
                toggleMuteTxt.enabled = true;
                backButton.enabled = true;
                backTxt.enabled = true;
                break;
        }
    }
    public void ExitGameButton()
    {
        Application.Quit();
        Debug.Log("Quitting Game!");
    }

    public void PlayGameButton()
    {
        SceneManager.LoadScene(introScene);
    }

    public void enterOptions()
    {
        inOptions = true;
    }

    public void exitOptions()
    {
        inOptions = false;
    }
}
