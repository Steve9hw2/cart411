
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndSceneScript : MonoBehaviour
{
    [SerializeField] private string menuScene = "Menu";
    private void Start()
    {
        GameObject endTextLabel = GameObject.Find("EndText");
        TMP_Text endText = endTextLabel.GetComponent<TMP_Text>();
        endText.text = "despite your best efforts, it seems you were unable to meet the goals set forth by corporate.";
    }

    public int currentParagraph = 0;

    public void progressText()
    {
        GameObject endTextLabel = GameObject.Find("EndText");
        TMP_Text endText = endTextLabel.GetComponent<TMP_Text>();
        switch (currentParagraph)
        {
            case 0:
                endText.text = "we understand that leaving a whole store to only one employee is a difficult task.";
                break;
            case 1:
                endText.text = "however, this was our last chance as a company to make profits to offset our debt.";
                break;
            case 2:
                endText.text = "you don't need to come in tomorrow. we're closing your store, effective immediately.";
                break;
            case 3:
                endText.text = "management didn't have money for severance after awarding bonuses...";
                break;
            case 4:
                endText.text = "...so don't say we didn't warn you. you're fired.";
                break;
            case 5:
                SceneManager.LoadScene(menuScene);
                break;
        }
        currentParagraph++;
    }
}
