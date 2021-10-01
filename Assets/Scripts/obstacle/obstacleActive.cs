using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleActive : MonoBehaviour
{
    [SerializeField]public List<GameObject> Childs;
    void Start() 
    {
        GetAllChlidObject();
    }
    void GetAllChlidObject()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Childs.Add(transform.GetChild(i).gameObject);
        }
    }
    public void SetobstacleActiveAndDeactive(bool isActive)
    {
        for (int i = 0; i < Childs.Count; i++)
        {
            Childs[i].gameObject.SetActive(isActive);
        }
    }    
}
