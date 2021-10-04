using JMRSDK.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class JioController : MonoBehaviour,  ITouchHandler //, IBackHandler
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
        currCountdownValue = MexTimeSecond;
        StartCoroutine(StartCountdown());
    }
    void WaitForSeconds()
    {
        if (IsInvoking("StartCountdown") == true)
            StopCoroutine("StartCountdown");
        
        CallTime = false;
        currCountdownValue = MexTimeSecond;
        StartCoroutine(StartCountdown());
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
    public void OnSwipeLeft(SwipeEventData eventData, float value)
    {
        //throw new System.NotImplementedException();
        if (CallTime == true)
        {
            playerController.MoveLeft();
            WaitForSeconds();
        }

    }

    public void OnSwipeRight(SwipeEventData eventData, float value)
    {
        //throw new System.NotImplementedException();
        if (CallTime == true)
        {
            playerController.MoveRight();
            WaitForSeconds();
        }

    }

   
    public void OnSwipeUp(SwipeEventData eventData, float value)
    {
        //throw new System.NotImplementedException();
        if (CallTime == true)
        {
            playerController.Jump();
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



}
