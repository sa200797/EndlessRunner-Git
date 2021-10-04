using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using JMRSDK.InputModule;
using UnityEngine.Events;
using System;

public class MainMenu : MonoBehaviour , IBackHandler
{
    [Space(15)]
    [SerializeField] UnityEvent OnBackButtonClick;
    [SerializeField] GameObject TutorialPanels;


    void Start()
    {
        Time.timeScale = 1;
        SetupBack();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("MainGame");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    void SetupBack()
    {
        OnBackButtonClick.AddListener(() =>
        {
            if (TutorialPanels == null)
            {
                Debug.Log("Object not file");
                return;
            }
            if (TutorialPanels != null)
            {
                if (TutorialPanels.gameObject.activeSelf == true)
                {
                    TutorialPanels.SetActive(false);
                }
            }

        });

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape");
            OnBackButtonClick.Invoke();
        }

    }

    public void OnBackAction()
    {
        OnBackButtonClick.Invoke();
    }
}
