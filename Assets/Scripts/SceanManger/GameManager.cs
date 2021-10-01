using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject JioCamera;
    [SerializeField] Vector3 JioCameraPostion;

    [SerializeField] GameObject JioCanvas;
    [SerializeField] Vector3 JioCanvasPostion;

    void Start()
    {
        SetupPostion();
    }

    private void SetupPostion()
    {
        if (JioCamera == null)
            JioCamera = GameObject.FindGameObjectWithTag("JioCamera");

        if (JioCamera == null)
            Debug.Log("Onject not Fill");
        else
            JioCamera.transform.position = JioCameraPostion;

        if (JioCanvas == null) 
        {
            JioCanvas = GameObject.FindGameObjectWithTag("JioCanvas");
        }
        if (JioCanvas == null)
        {
            Debug.Log("Object Not Fill");
        }
        else 
        {
            JioCanvas.GetComponent<RectTransform>().anchoredPosition3D = JioCanvasPostion;
        }


        
    }

   
}
