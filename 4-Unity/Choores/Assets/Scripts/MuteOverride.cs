
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MuteOverride : MonoBehaviour
{
    public static bool musicMuted;

    // Update is called once per frame
    void Update()
    {
        GameObject musicLabel = GameObject.Find("Music");
        AudioSource music = musicLabel.GetComponent<AudioSource>();
        GameObject musicD1Label = GameObject.Find("MusicDay1");
        AudioSource musicD1 = musicD1Label.GetComponent<AudioSource>();
        GameObject musicD2Label = GameObject.Find("MusicDay2");
        AudioSource musicD2 = musicD2Label.GetComponent<AudioSource>();
        GameObject musicD3Label = GameObject.Find("MusicDay3");
        AudioSource musicD3 = musicD3Label.GetComponent<AudioSource>();
        GameObject musicD4Label = GameObject.Find("MusicDay4");
        AudioSource musicD4 = musicD4Label.GetComponent<AudioSource>();
        GameObject musicD5Label = GameObject.Find("MusicDay5");
        AudioSource musicD5 = musicD5Label.GetComponent<AudioSource>();
        GameObject musicD6Label = GameObject.Find("MusicDay6");
        AudioSource musicD6 = musicD6Label.GetComponent<AudioSource>();
        GameObject musicD7Label = GameObject.Find("MusicDay7");
        AudioSource musicD7 = musicD7Label.GetComponent<AudioSource>();
        GameObject musicEDLabel = GameObject.Find("MusicDayEnd");
        AudioSource musicED = musicEDLabel.GetComponent<AudioSource>();


        if (musicMuted)
        {
            music.volume = 0;
            musicD1.volume = 0;
            musicD2.volume = 0;
            musicD3.volume = 0;
            musicD4.volume = 0;
            musicD5.volume = 0;
            musicD6.volume = 0;
            musicD7.volume = 0;
            musicED.volume = 0;
        }
        else
        {
            music.volume = 1;
            musicD1.volume = 1;
            musicD2.volume = 1;
            musicD3.volume = 1;
            musicD4.volume = 1;
            musicD5.volume = 1;
            musicD6.volume = 1;
            musicD7.volume = 1;
        }


    }

    public void muteToggle()
    {
        GameObject toggleMuteButtonLabel = GameObject.Find("ToggleMuteButton");
        Image toggleMuteButton = toggleMuteButtonLabel.GetComponent<Image>();
        GameObject toggleMuteTxtLabel = GameObject.Find("ToggleMute");
        TMP_Text toggleMuteTxt = toggleMuteTxtLabel.GetComponent<TMP_Text>();

        switch (musicMuted)
        {
            case false:
                toggleMuteTxt.text = "UNMUTE";
                musicMuted = true;
                break;
            case true:
                toggleMuteTxt.text = "MUTE";
                musicMuted = false;
                break;
        }
    }
}

