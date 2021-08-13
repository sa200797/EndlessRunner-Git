/*Example to use Interfaces to add interaction of objects/UI*/

using JMRSDK.InputModule;
using UnityEngine;
public class InterfaceExample : MonoBehaviour, ISelectHandler,
  ISelectClickHandler, IFocusable, ISwipeHandler, ITouchHandler,
  IBackHandler, IMenuHandler, IVoiceHandler, IFn1Handler,
  IFn2Handler, IManipulationHandler
{

    public PlayerController playerController;


    void Awake()
    {
        playerController = GetComponent<PlayerController>();
        JMRInputManager.Instance.AddGlobalListener(gameObject);
    }
        

    public void OnBackAction()
    {
        //  LevelEvents.instance.PausePannel();

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




    public void OnFn1Action()
    {
        Debug.Log("OnFn1Action");
    }

    public void OnFn2Action()
    {
        Debug.Log("OnFn2Action");
    }

    public void OnFocusEnter()
    {
        Debug.Log("OnFocusEnter");
    }

    public void OnFocusExit()
    {
        Debug.Log("OnFocusExit");
    }

    public void OnManipulationCompleted(ManipulationEventData eventData)
    {
        Debug.Log("OnManipulationCompleted");
    }

    public void OnManipulationStarted(ManipulationEventData eventData)
    {
        Debug.Log("OnManipulationStarted");
    }

    public void OnManipulationUpdated(ManipulationEventData eventData)
    {
        Debug.Log("OnManipulationUpdated");
    }

    public void OnMenuAction()
    {
        Debug.Log("OnMenuAction");
    }

    public void OnSelectClicked(SelectClickEventData eventData)
    {
        Debug.Log("OnSelectClicked");

    }

    public void OnSelectDown(SelectEventData eventData)
    {
        Debug.Log("OnSelectDown");
       // StartCoroutine(playerController.Slide());

    }

    public void OnSelectUp(SelectEventData eventData)
    {
        Debug.Log("OnSelectUp");
        //playerController.Jump();

    }

    public void OnSwipeCanceled(SwipeEventData eventData)
    {
        Debug.Log("OnSwipeCanceled");
    }

    public void OnSwipeCompleted(SwipeEventData eventData)
    {
        Debug.Log("OnSwipeCompleted");
    }

    public void OnSwipeDown(SwipeEventData eventData, float delta)
    {
        Debug.Log("OnSwipeDown");
        StartCoroutine(playerController.Slide());
    }

    public void OnSwipeLeft(SwipeEventData eventData, float delta)
    {
        Debug.Log("OnSwipeLeft");
        playerController.MoveLeft();

    }

    public void OnSwipeRight(SwipeEventData eventData, float delta)
    {
        Debug.Log("OnSwipeRight");
        playerController.MoveRight();
    }

    public void OnSwipeStarted(SwipeEventData eventData)
    {
        Debug.Log("OnSwipeStarted");
    }

    public void OnSwipeUp(SwipeEventData eventData, float delta)
    {
        Debug.Log("OnSwipeUp");
        playerController.Jump();

    }

    public void OnSwipeUpdated(SwipeEventData eventData, Vector2 delta)
    {
        Debug.Log("OnSwipeUpdated");
    }

    public void OnVoiceAction()
    {
        Debug.Log("OnVoiceAction");
    }

    public void OnTouchStart(TouchEventData eventData, Vector2 TouchData)
    {
        Debug.Log("OnTouchStarted " + TouchData.ToString());
    }

    public void OnTouchStop(TouchEventData eventData, Vector2 TouchData)
    {
        Debug.Log("OnTouchStop " + TouchData.ToString());
    }

    public void OnTouchUpdated(TouchEventData eventData, Vector2 TouchData)
    {
        Debug.Log("OnTouchUpdated " + TouchData.ToString());
    }

}