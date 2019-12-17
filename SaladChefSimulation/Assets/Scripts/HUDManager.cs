using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HUDManager : MonoBehaviour
{
    public GameObject playerOneWininMessage, playerTwoWininMessage,playerDrawMessage;
    public GameObject playerOneScoreHUD, playerOneTimerHUD, playerTwoScoreHUD, playerTwoTimerHUD;
    public GameObject helpButton, helpScreen;
    private MiscelleniousManager miscelleniousManager;
    public GameObject miscellinious;

    // Start is called before the first frame update
    void Start()
    {
        //initialization done regarding HUDS
        helpScreen.SetActive(false);
        helpButton.SetActive(true);
        miscelleniousManager = miscellinious.GetComponent<MiscelleniousManager>();
        playerOneWininMessage.SetActive(false);
        playerTwoWininMessage.SetActive(false);
        playerDrawMessage.SetActive(false);        
    }

    // Update is called once per frame
    void Update()
    {
        //continuous monitoring the values of HUD element
        playerOneScoreHUD.GetComponent<Text>().text = ("SCORE : " + miscelleniousManager.playerOneScore);
        playerTwoScoreHUD.GetComponent<Text>().text = ("SCORE : " + miscelleniousManager.playerTwoScore);
        playerOneTimerHUD.GetComponent<Text>().text = ("TIME : " + (int)miscelleniousManager.playerOneTime);
        playerTwoTimerHUD.GetComponent<Text>().text = ("TIME : " + (int)miscelleniousManager.playerTwoTime);
    }
    public void ExitApplication()
    {
        Application.Quit();
    }
    public void ReplayGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("GamePlayAScene");
    }
    public void HelpButtonHandler()
    {
        helpScreen.SetActive(true);
        helpButton.SetActive(false);
        Time.timeScale = 0;
    }
    public void HelpScreenHandler()
    {
        helpScreen.SetActive(false);
        helpButton.SetActive(true);
        Time.timeScale = 1.0f;
    }
}
