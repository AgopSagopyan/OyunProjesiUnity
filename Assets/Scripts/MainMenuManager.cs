using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject levelSelectPanel;

    public StateUI stateUI;

    // PLAY
    public void PlayGame()
    {
        mainMenuPanel.SetActive(false);
        levelSelectPanel.SetActive(true);

        stateUI.isFirstTime = false;


    }

    // GERİ DÖN
    public void BackToMenu()
    {
        levelSelectPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    // LEVEL 1
    public void LoadLevel1()
    {
        LoadingManager.Load("TestStage");
    }

    public void LoadLevel2()
    {
        LoadingManager.Load("Episode2");
    }

    public void LoadLevel3()
    {
        LoadingManager.Load("Episode3");
    }

    void Awake()
    {
        if(stateUI.isFirstTime)
        {
            mainMenuPanel.SetActive(true);
            levelSelectPanel.SetActive(false);
        }

    }
}