using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonUI : MonoBehaviour
{
    [SerializeField] private string mainGameScene = "Intro";
    public void ExitGameButton()
    {
        Application.Quit();
        Debug.Log("Quitting Game!");
    }

    public void PlayGameButton()
    {
        SceneManager.LoadScene(mainGameScene);
    }
}
