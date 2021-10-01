using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviour
{
    

   // public Animator messageAnim;

    private void Start()
    {
        Time.timeScale = 1;
    }
    private void Update()
    {
     


        //if(Input.GetKeyDown(KeyCode.M))
        //{
        //    PlayGame();
        //}
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    

    public void QuitGame()
    {
        Application.Quit();
    }
}
