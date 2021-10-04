using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
   // public GameObject gameOverPanel;

    public static bool isGameStarted;
    //public GameObject startingText;
    //public GameObject newRecordPanel;

    public static int score;
    //public TextMeshProUGUI scoreText;
    //public TextMeshProUGUI GO_scoreText;
    //public TextMeshProUGUI gemsText;
    //public TextMeshProUGUI newRecordText;

    public static bool isGamePaused;
    public GameObject[] characterPrefabs;

    public GameObject child;

    private void Awake()
    {
        //PlayerPrefs.DeleteAll();
        int index = PlayerPrefs.GetInt("SelectedCharacter");
        GameObject go = Instantiate(characterPrefabs[index], transform.position, Quaternion.identity);

        child = GameObject.FindGameObjectWithTag("Jio");

    }

    void Start()
    {
        score = 0;
        Time.timeScale = 1;
        gameOver = isGameStarted = isGamePaused= false;
        //gameOverPanel.SetActive(false);

    }

    void Update()
    {
        //Update UI

        FindObject.instance.gemsText.text = PlayerPrefs.GetInt("TotalGems", 0).ToString();
        FindObject.instance.scoreText.text = score.ToString();
        FindObject.instance.GO_scoreText.text = score.ToString();

        //Game Over
        if (gameOver)
        {
           
            if (score > PlayerPrefs.GetInt("HighScore", 0))
            {
                //newRecordPanel.SetActive(true);
                FindObject.instance.newRecordText.text = "New \nRecord\n" + score;
                PlayerPrefs.SetInt("HighScore", score);
            }
            else
            {
            }

            if (FindObject.instance.gameOverPanel == null) 
            {
                Debug.Log("gameOverPanel is null");
            }

                

            //child.transform.SetParent(null);
            if(FindObject.instance.gameOverPanel != null)
                FindObject.instance.gameOverPanel.SetActive(true);
            //Destroy(gameObject);
            Time.timeScale = 0;
        }

        //Start Game  on Tap 
        //if (SwipeManager.tap && !isGameStarted || Input.GetKeyDown(KeyCode.J))
        //{
        //    isGameStarted = true;
        //    Destroy(startingText);
        //}
        
        /*if (!isGameStarted && Input.GetKeyDown(KeyCode.J))
        {
            isGameStarted = true;
            Destroy(startingText);
        }*/
    }


    public void GameStart()  /// Game Starts By Pressing Button
    {
        if(!isGameStarted)
        {
            isGameStarted = true;
            GameObject.Find("RoadManager").gameObject.GetComponent<obstacleShow>().ShowObstacleOnStartClick();
            Debug.Log("Game Start");
        }

    }
}
