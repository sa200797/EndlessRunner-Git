using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class LevelEvents : MonoBehaviour
{
    public static LevelEvents instance;

    // GameObject child;
    // public GameObject gamePausedPanel;
    //  public Button pauseButton; 


    private void Update()
    {
        if (!PlayerManager.isGameStarted)
            return;

        if (PlayerManager.gameOver)
            // pauseButton.interactable = false;

            if (PlayerManager.gameOver)
                return;


        if (Input.GetKeyDown(KeyCode.Escape))
        {
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


        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            ReplayGame();
        }

        FindObject.instance.highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        FindObject.instance.gems_Text.text = PlayerPrefs.GetInt("TotalGems", 0).ToString();
    }
    public void ReplayGame()
    {
        SceneManager.LoadScene("MainGame");

    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
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
    public void QuitGame()
    {
        Application.Quit();
    }



    public void PausePannel()
    {
        if (!PlayerManager.isGameStarted)
            return;



        if (PlayerManager.gameOver)
            return;


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

    public void changeScene(string SceneName)
    {
       
        if (UnityEngine.SceneManagement.SceneManager.GetSceneByName(SceneName).IsValid() == false)
        {
            SceneManager.LoadScene(SceneName);
        }
        else
        {
            Debug.LogWarning("Load Scene Failed. " + SceneName + " not found.");
        }
        


    }

}
