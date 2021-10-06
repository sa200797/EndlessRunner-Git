using JMRSDK.InputModule;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BackButtonClick : MonoBehaviour, IBackHandler
{
    [SerializeField] UnityEvent OnBackButtonClick;
    [SerializeField] GameObject TutorialPanels;
    [SerializeField] LevelEvents levelEvents;
    //[SerializeField] GameObject TutorialPanels;


    void Start()
    {
        JMRInputManager.Instance.AddGlobalListener(gameObject);

        SetupBack();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Back Click");
            OnBackButtonClick.Invoke();
        }
    }


    void SetupBack()
    {
        OnBackButtonClick.AddListener(() =>
        {

            if (TutorialPanels == null)
            {
                Debug.Log("Object not file");
                //return;
            }

            if (TutorialPanels != null)
            {
                if (TutorialPanels.gameObject.activeSelf == true)
                {
                    TutorialPanels.SetActive(false);
                    return;
                }
            }

            if (levelEvents == null) 
            {
                levelEvents = GameObject.Find("Events").GetComponent<LevelEvents>();
            }

            if (!PlayerManager.isGameStarted) 
            {
                levelEvents.changeScene("Menu");
            }

            if (PlayerManager.gameOver == true) 
            {
                levelEvents.changeScene("Menu");
            }
        });
    }
    public void OnBackAction()
    {
        if (!PlayerManager.isGameStarted || PlayerManager.gameOver)
        {
            OnBackButtonClick.Invoke();
            return;
        }

        //  Debug.Log("OnBackAction");
        if (PlayerManager.isGamePaused)
        {
            ResumeGame();
            FindObject.instance.gamePausedPanel.SetActive(false);
        }
        else
        {
            PauseGame();
            FindObject.instance.gamePausedPanel.SetActive(true);
        }
    }
    public void PauseGame()
    {
        if (!PlayerManager.isGamePaused && !PlayerManager.gameOver)
        {
            Time.timeScale = 0;
            PlayerManager.isGamePaused = true;
        }
    }
    public void ResumeGame()
    {
        if (PlayerManager.isGamePaused)
        {
            Time.timeScale = 1;
            PlayerManager.isGamePaused = false;
        }
    }

}
