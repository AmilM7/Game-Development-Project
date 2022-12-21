using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Events : MonoBehaviour
{

    public GameObject CreditsPanel;
    public GameObject HelpPanel;
    public GameObject PausePanel;
    public GameObject overlay;
    
    public void ReplayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("StartScene"); 
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenCredits()
    {
        CreditsPanel.SetActive(true);
    }

    public void CloseCredits()
    {
        CreditsPanel.SetActive(false);
    }

    public void OpenHelp()
    {
        HelpPanel.SetActive(true);
    }

    public void CloseHelp()
    {
        HelpPanel.SetActive(false);
    }

    public void OpenPause()
    {
        PausePanel.SetActive(true);
        Time.timeScale=0;
        overlay.SetActive(false);
    }

    public void ClosePause()
    {
        PausePanel.SetActive(false);
        Time.timeScale=1;
        overlay.SetActive(true);
        
    }
}
