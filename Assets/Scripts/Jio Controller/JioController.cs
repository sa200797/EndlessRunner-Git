using JMRSDK.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class JioController : MonoBehaviour
    , ITouchHandler
    //, IBackHandler
    , ISelectHandler
    , ISelectClickHandler
    , IFocusable
    , ISwipeHandler  
    , IMenuHandler
    , IVoiceHandler
    , IFn1Handler
    , IFn2Handler
    , IManipulationHandler
{   

    [SerializeField] bool CallTime;

    [SerializeField][Range(0,5)] int MexTimeSecond;
    [SerializeField][Range(0,1)] float WaitTimeMillisecond;
    [SerializeField] float currCountdownValue;
    public PlayerController playerController;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        JMRInputManager.Instance.AddGlobalListener(gameObject);

        OnGameStart();

        
    }     
    public IEnumerator StartCountdown()
    {
        if (CallTime == true)
        {
            StopCoroutine(StartCountdown());
            yield break;
        }

        while (currCountdownValue >= 0)
        {
            if (CallTime == true)
            {
                StopCoroutine(StartCountdown());
                yield break;
            }

            Debug.Log("Countdown: " + currCountdownValue);

            if (currCountdownValue == 0) 
            {
                CallTime = true;
                
                yield break;
            }
            yield return new WaitForSeconds(WaitTimeMillisecond);
            currCountdownValue--;
        }
    }

    void OnGameStart() 
    {
        CallTime = true;
        //currCountdownValue = MexTimeSecond;
        //StartCoroutine(StartCountdown());
    }
    void WaitForSeconds()
    {
        if (IsInvoking("StartCountdown") == true)
            StopCoroutine("StartCountdown");
        
        CallTime = false;
        currCountdownValue = MexTimeSecond;
        StartCoroutine(StartCountdown());
    }

    public void OnSwipeStarted(SwipeEventData eventData)
    {
        //throw new System.NotImplementedException();
    }

    public void OnSwipeUpdated(SwipeEventData eventData, Vector2 swipeData)
    {
        //throw new System.NotImplementedException();
    }

    public void OnSwipeCompleted(SwipeEventData eventData)
    {
        //throw new System.NotImplementedException();
    }

    public void OnSwipeCanceled(SwipeEventData eventData)
    {
        //throw new System.NotImplementedException();
    }


    public void OnSwipeDown(SwipeEventData eventData, float value)
    {
        //throw new System.NotImplementedException();
        Debug.Log("OnSwipeDown");
        if (CallTime == true)
        {
            StartCoroutine(playerController.Slide());
            WaitForSeconds();
        }
    }
    public void OnSwipeUp(SwipeEventData eventData, float value)
    {
        //throw new System.NotImplementedException();
        Debug.Log("OnSwipeUp");
        if (CallTime == true)
        {
            playerController.Jump();
            WaitForSeconds();
        }

    }
    public void OnSwipeLeft(SwipeEventData eventData, float value)
    {
        //throw new System.NotImplementedException();
        Debug.Log("OnSwipeLeft");
        if (CallTime == true)
        {
            playerController.MoveLeft();
            WaitForSeconds();
        }

    }
    public void OnSwipeRight(SwipeEventData eventData, float value)
    {
        //throw new System.NotImplementedException();
        Debug.Log("OnSwipeRight");
        if (CallTime == true)
        {
            playerController.MoveRight();
            WaitForSeconds();
        }

    }
    public void OnTouchStart(TouchEventData eventData, Vector2 TouchData)
    {
        CallTime = true;
    }

    public void OnTouchStop(TouchEventData eventData, Vector2 TouchData)
    {

    }

    public void OnTouchUpdated(TouchEventData eventData, Vector2 TouchData)
    {

    }

    /*public void OnBackAction()
    {
        //throw new System.NotImplementedException();
    }*/

    public void OnSelectDown(SelectEventData eventData)
    {
        //throw new System.NotImplementedException();
    }

    public void OnSelectUp(SelectEventData eventData)
    {
        //throw new System.NotImplementedException();
    }

    public void OnSelectClicked(SelectClickEventData eventData)
    {
        //throw new System.NotImplementedException();
    }

    public void OnFn1Action()
    {
        //throw new System.NotImplementedException();
    }

    public void OnFn2Action()
    {
        //throw new System.NotImplementedException();
    }

    public void OnFocusEnter()
    {
        //throw new System.NotImplementedException();
    }

    public void OnFocusExit()
    {
        //throw new System.NotImplementedException();
    }

    public void OnVoiceAction()
    {
        //throw new System.NotImplementedException();
    }

    public void OnManipulationStarted(ManipulationEventData eventData)
    {
        //throw new System.NotImplementedException();
    }

    public void OnManipulationUpdated(ManipulationEventData eventData)
    {
        //throw new System.NotImplementedException();
    }

    public void OnManipulationCompleted(ManipulationEventData eventData)
    {
        //throw new System.NotImplementedException();
    }

    public void OnMenuAction()
    {
        //throw new System.NotImplementedException();
    }
}
