
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class IntroSceneManager : MonoBehaviour
{
    [SerializeField] private string mainSceneName = "Main";

    public int currentParagraph;
    // Start is called before the first frame update
    void Start()
    {
        GameObject musicLabel = GameObject.Find("Music");
        AudioSource music = musicLabel.GetComponent<AudioSource>();

        GameObject introTextLabel = GameObject.Find("IntroText");
        TMP_Text introText = introTextLabel.GetComponent<TMP_Text>();
        GameObject speakerNameLabel = GameObject.Find("NameText");
        TMP_Text speakerName = speakerNameLabel.GetComponent<TMP_Text>();

        GameObject yajobImg1Label = GameObject.Find("Yajob1");
        Image yajobImg1 = yajobImg1Label.GetComponent<Image>();
        GameObject yajobImg2Label = GameObject.Find("Yajob2");
        Image yajobImg2 = yajobImg2Label.GetComponent<Image>();
        GameObject yajobImg3Label = GameObject.Find("Yajob3");
        Image yajobImg3 = yajobImg3Label.GetComponent<Image>();
        GameObject yajobImg4Label = GameObject.Find("Yajob4");
        Image yajobImg4 = yajobImg4Label.GetComponent<Image>();
        GameObject yajobImg5Label = GameObject.Find("Yajob5");
        Image yajobImg5 = yajobImg5Label.GetComponent<Image>();
        GameObject yajobImg6Label = GameObject.Find("Yajob6");
        Image yajobImg6 = yajobImg6Label.GetComponent<Image>();
        GameObject blackoutLabel = GameObject.Find("Blackout");
        Image blackout = blackoutLabel.GetComponent<Image>();

        introText.text = "...oh good, i made it on time.";
        speakerName.text = "you";

        yajobImg1.enabled = false;
        yajobImg2.enabled = false;
        yajobImg3.enabled = false;
        yajobImg4.enabled = false;
        yajobImg5.enabled = false;
        yajobImg6.enabled = false;
        blackout.enabled = true;

    }


    public void advanceText()
    {
        GameObject introTextLabel = GameObject.Find("IntroText");
        TMP_Text introText = introTextLabel.GetComponent<TMP_Text>();
        GameObject speakerNameLabel = GameObject.Find("NameText");
        TMP_Text speakerName = speakerNameLabel.GetComponent<TMP_Text>();

        GameObject yajobImg1Label = GameObject.Find("Yajob1");
        Image yajobImg1 = yajobImg1Label.GetComponent<Image>();
        GameObject yajobImg2Label = GameObject.Find("Yajob2");
        Image yajobImg2 = yajobImg2Label.GetComponent<Image>();
        GameObject yajobImg3Label = GameObject.Find("Yajob3");
        Image yajobImg3 = yajobImg3Label.GetComponent<Image>();
        GameObject yajobImg4Label = GameObject.Find("Yajob4");
        Image yajobImg4 = yajobImg4Label.GetComponent<Image>();
        GameObject yajobImg5Label = GameObject.Find("Yajob5");
        Image yajobImg5 = yajobImg5Label.GetComponent<Image>();
        GameObject yajobImg6Label = GameObject.Find("Yajob6");
        Image yajobImg6 = yajobImg6Label.GetComponent<Image>();
        GameObject blackoutLabel = GameObject.Find("Blackout");
        Image blackout = blackoutLabel.GetComponent<Image>();

        switch (currentParagraph)
        {
            case 0:
                yajobImg1.enabled = false;
                yajobImg2.enabled = false;
                yajobImg3.enabled = false;
                yajobImg4.enabled = false;
                yajobImg5.enabled = false;
                yajobImg6.enabled = false;
                blackout.enabled = true;
                speakerName.text = "you";
                introText.text = "...what was with that box out front? It was pretty big.";
                break;
            case 1:
                yajobImg1.enabled = false;
                yajobImg2.enabled = false;
                yajobImg3.enabled = false;
                yajobImg4.enabled = false;
                yajobImg5.enabled = false;
                yajobImg6.enabled = false;
                blackout.enabled = true;
                speakerName.text = "you";
                introText.text = "...oh, the meeting's starting.";
                break;
            case 2:
                yajobImg1.enabled = true;
                yajobImg2.enabled = false;
                yajobImg3.enabled = false;
                yajobImg4.enabled = false;
                yajobImg5.enabled = false;
                yajobImg6.enabled = false;
                blackout.enabled = false;
                speakerName.text = "Rob Y. Jobs";
                introText.text = "Hello friends! It is I, Robert Yale Jobs!";
                break;
            case 3:
                yajobImg1.enabled = false;
                yajobImg2.enabled = true;
                yajobImg3.enabled = false;
                yajobImg4.enabled = false;
                yajobImg5.enabled = false;
                yajobImg6.enabled = false;
                blackout.enabled = false;
                speakerName.text = "Rob Y. Jobs";
                introText.text = "Your favourite manage-man is here with news!";
                break;
            case 4:
                yajobImg1.enabled = true;
                yajobImg2.enabled = false;
                yajobImg3.enabled = false;
                yajobImg4.enabled = false;
                yajobImg5.enabled = false;
                yajobImg6.enabled = false;
                blackout.enabled = false;
                speakerName.text = "Rob Y. Jobs";
                introText.text = "The CEO's private yacht fleet had a great time on the private island they bought!";
                break;
            case 5:
                yajobImg1.enabled = false;
                yajobImg2.enabled = false;
                yajobImg3.enabled = true;
                yajobImg4.enabled = false;
                yajobImg5.enabled = false;
                yajobImg6.enabled = false;
                blackout.enabled = false;
                speakerName.text = "Rob Y. Jobs";
                introText.text = "When I told the guys in accounting about it, though, I got a rather strange reply....";
                break;
            case 6:
                yajobImg1.enabled = false;
                yajobImg2.enabled = true;
                yajobImg3.enabled = false;
                yajobImg4.enabled = false;
                yajobImg5.enabled = false;
                yajobImg6.enabled = false;
                blackout.enabled = false;
                speakerName.text = "Rob Y. Jobs";
                introText.text = "ahhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh... or something to that effect.";
                break;
            case 7:
                yajobImg1.enabled = false;
                yajobImg2.enabled = false;
                yajobImg3.enabled = true;
                yajobImg4.enabled = false;
                yajobImg5.enabled = false;
                yajobImg6.enabled = false;
                blackout.enabled = false;
                speakerName.text = "Rob Y. Jobs";
                introText.text = "I just thought they were jealous about not being invited... but it would seem not.";
                break;
            case 8:
                yajobImg1.enabled = false;
                yajobImg2.enabled = false;
                yajobImg3.enabled = true;
                yajobImg4.enabled = false;
                yajobImg5.enabled = false;
                yajobImg6.enabled = false;
                blackout.enabled = false;
                speakerName.text = "Rob Y. Jobs";
                introText.text = "Allow me to be frank, team.";
                break;
            case 9:
                yajobImg1.enabled = false;
                yajobImg2.enabled = false;
                yajobImg3.enabled = true;
                yajobImg4.enabled = false;
                yajobImg5.enabled = false;
                yajobImg6.enabled = false;
                blackout.enabled = false;
                speakerName.text = "Frank";
                introText.text = "We do not have the money to keep you employed.";
                break;
            case 10:
                yajobImg1.enabled = false;
                yajobImg2.enabled = false;
                yajobImg3.enabled = false;
                yajobImg4.enabled = true;
                yajobImg5.enabled = false;
                yajobImg6.enabled = false;
                blackout.enabled = false;
                speakerName.text = "Frank";
                introText.text = "Effectively immediately, we are laying off 97% of our workforce.";
                break;
            case 11:
                yajobImg1.enabled = false;
                yajobImg2.enabled = false;
                yajobImg3.enabled = false;
                yajobImg4.enabled = true;
                yajobImg5.enabled = false;
                yajobImg6.enabled = false;
                blackout.enabled = false;
                speakerName.text = "Frank";
                introText.text = "There will be no severance packages. Take your concerns up with legal.";
                break;
            case 12:
                yajobImg1.enabled = false;
                yajobImg2.enabled = false;
                yajobImg3.enabled = false;
                yajobImg4.enabled = false;
                yajobImg5.enabled = true;
                yajobImg6.enabled = false;
                blackout.enabled = false;
                speakerName.text = "Frank";
                introText.text = "Now, you may wonder about the remaining 3% of staff...";
                break;
            case 13:
                yajobImg1.enabled = false;
                yajobImg2.enabled = false;
                yajobImg3.enabled = false;
                yajobImg4.enabled = false;
                yajobImg5.enabled = true;
                yajobImg6.enabled = false;
                blackout.enabled = false;
                speakerName.text = "Frank";
                introText.text = "Apparently, the CEO invested in something of a... gamble.";
                break;
            case 14:
                yajobImg1.enabled = false;
                yajobImg2.enabled = false;
                yajobImg3.enabled = false;
                yajobImg4.enabled = false;
                yajobImg5.enabled = true;
                yajobImg6.enabled = false;
                blackout.enabled = false;
                speakerName.text = "Frank";
                introText.text = "One store among you has received a special package.";
                break;
            case 15:
                yajobImg1.enabled = false;
                yajobImg2.enabled = false;
                yajobImg3.enabled = false;
                yajobImg4.enabled = false;
                yajobImg5.enabled = true;
                yajobImg6.enabled = false;
                blackout.enabled = false;
                speakerName.text = "Frank";
                introText.text = "This package contains a revolutionary robot, capable of serving our clientele.";
                break;
            case 16:
                yajobImg1.enabled = false;
                yajobImg2.enabled = false;
                yajobImg3.enabled = false;
                yajobImg4.enabled = false;
                yajobImg5.enabled = false;
                yajobImg6.enabled = true;
                blackout.enabled = false;
                speakerName.text = "Frank";
                introText.text = "To you, the manager of our remaining store!";
                break;
            case 17:
                yajobImg1.enabled = false;
                yajobImg2.enabled = false;
                yajobImg3.enabled = false;
                yajobImg4.enabled = false;
                yajobImg5.enabled = false;
                yajobImg6.enabled = true;
                blackout.enabled = false;
                speakerName.text = "Frank";
                introText.text = "Hurry and head home! Today, you'll be piloting the servicebot remotely!";
                break;
            case 18:
                yajobImg1.enabled = false;
                yajobImg2.enabled = false;
                yajobImg3.enabled = false;
                yajobImg4.enabled = false;
                yajobImg5.enabled = false;
                yajobImg6.enabled = true;
                blackout.enabled = false;
                speakerName.text = "Frank";
                introText.text = "I won't bore you with the details, but it is far more efficient than any human.";
                break;
            case 19:
                yajobImg1.enabled = false;
                yajobImg2.enabled = false;
                yajobImg3.enabled = false;
                yajobImg4.enabled = false;
                yajobImg5.enabled = false;
                yajobImg6.enabled = true;
                blackout.enabled = false;
                speakerName.text = "Frank";
                introText.text = "If you can exceed the expectations of the guys down in accounting...";
                break;
            case 20:
                yajobImg1.enabled = false;
                yajobImg2.enabled = false;
                yajobImg3.enabled = false;
                yajobImg4.enabled = false;
                yajobImg5.enabled = true;
                yajobImg6.enabled = false;
                blackout.enabled = false;
                speakerName.text = "Frank";
                introText.text = "Then this company may yet have a future.";
                break;
            case 21:
                yajobImg1.enabled = false;
                yajobImg2.enabled = false;
                yajobImg3.enabled = false;
                yajobImg4.enabled = false;
                yajobImg5.enabled = true;
                yajobImg6.enabled = false;
                blackout.enabled = false;
                speakerName.text = "Frank";
                introText.text = "So go on! Lead the company to a brighter future!";
                break;
            case 22:
                yajobImg1.enabled = false;
                yajobImg2.enabled = false;
                yajobImg3.enabled = false;
                yajobImg4.enabled = false;
                yajobImg5.enabled = true;
                yajobImg6.enabled = false;
                blackout.enabled = false;
                speakerName.text = "Frank";
                introText.text = "As for me and the rest of you... we're no longer needed.";
                break;
            case 23:
                yajobImg1.enabled = false;
                yajobImg2.enabled = false;
                yajobImg3.enabled = false;
                yajobImg4.enabled = false;
                yajobImg5.enabled = true;
                yajobImg6.enabled = false;
                blackout.enabled = false;
                speakerName.text = "Frank";
                introText.text = "Once again, take your concerns up with legal. I'm just the messenger.";
                break;
            case 24:
                yajobImg1.enabled = false;
                yajobImg2.enabled = false;
                yajobImg3.enabled = false;
                yajobImg4.enabled = false;
                yajobImg5.enabled = false;
                yajobImg6.enabled = false;
                blackout.enabled = true;
                speakerName.text = "you";
                introText.text = "...";
                break;
            case 25:
                yajobImg1.enabled = false;
                yajobImg2.enabled = false;
                yajobImg3.enabled = false;
                yajobImg4.enabled = false;
                yajobImg5.enabled = false;
                yajobImg6.enabled = false;
                blackout.enabled = true;
                speakerName.text = "you";
                introText.text = "...he really ended it with that?";
                break;
            case 26:
                yajobImg1.enabled = false;
                yajobImg2.enabled = false;
                yajobImg3.enabled = false;
                yajobImg4.enabled = false;
                yajobImg5.enabled = false;
                yajobImg6.enabled = false;
                blackout.enabled = true;
                speakerName.text = "you";
                introText.text = "...the hell is wrong with this company...";
                break;
            case 27:
                yajobImg1.enabled = false;
                yajobImg2.enabled = false;
                yajobImg3.enabled = false;
                yajobImg4.enabled = false;
                yajobImg5.enabled = false;
                yajobImg6.enabled = false;
                blackout.enabled = true;
                speakerName.text = "you";
                introText.text = "...guess I should get ready to pilot that thing.";
                break;
            case 28:
                yajobImg1.enabled = false;
                yajobImg2.enabled = false;
                yajobImg3.enabled = false;
                yajobImg4.enabled = false;
                yajobImg5.enabled = false;
                yajobImg6.enabled = false;
                blackout.enabled = true;
                speakerName.text = "you";
                introText.text = "...how hard can it really be?";
                break;
            case 29:
                SceneManager.LoadScene(mainSceneName);
                break;
        }
        currentParagraph++;
    }

    public void skipIntro()
    {
        SceneManager.LoadScene(mainSceneName);
    }
}
