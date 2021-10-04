using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FindObject : MonoBehaviour
{
    public static FindObject instance;

    // Start is called before the first frame update

    public GameObject gameOverPanel;
    public  TextMeshProUGUI scoreText;
    public  TextMeshProUGUI GO_scoreText;
    public  TextMeshProUGUI gemsText;
    public  TextMeshProUGUI newRecordText;



    public GameObject gamePausedPanel;

    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI gems_Text;


    private void Awake()
    {
        //PlayerPrefs.DeleteAll();
          if (instance == null)
                instance = this;
            else
            {
                Destroy(gameObject);
            }

       // DontDestroyOnLoad(gameObject);
    }

}
