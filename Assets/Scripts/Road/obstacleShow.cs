using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class obstacleShow : MonoBehaviour
{
    [SerializeField] List<GameObject> RoadHolder;
    [SerializeField] List<float> RoadHolderMexPostion;
    [SerializeField] List<float> roadDistances;

    [SerializeField] GameObject PlayerPostion;
    [SerializeField] List<GameObject> AllObstacle;
    [SerializeField] List<GameObject> selectedObstacle;
    [SerializeField] List<GameObject> ignoreObstacle;

    void Start()
    {
        OnStartSetupObstaleCall();
        HideAll();
    }
    void ShowAll()
    {
        if (AllObstacle.Count == 0)
        {
            Debug.Log("Object not fill");
        }
        Debug.Log(AllObstacle.Count);

        for (int i = 0; i < AllObstacle.Count; i++)
        {
            AllObstacle[i].gameObject.GetComponent<obstacleActive>().SetobstacleActiveAndDeactive(true);
        }
    }
    void HideAll()
    {
        if (AllObstacle.Count == 0)
        {
            Debug.Log("Object not fill");
           
        }

        Debug.Log(AllObstacle.Count);

        for (int i = 0; i < AllObstacle.Count; i++)
        {
            AllObstacle[i].gameObject.GetComponent<obstacleActive>().SetobstacleActiveAndDeactive(false);
        }
    }
    void OnStartSetupObstaleCall()
    {
        if (RoadHolder.Count == 0) 
        {
            Debug.Log(RoadHolder.Count);
            if (RoadHolder.Count == 0) { RoadHolder = GetComponent<RaodRunSetup>().RoadHoder; }
            Debug.Log(RoadHolder.Count);

        }
        AllObstacle = new List<GameObject>();        
        for (int i = 0; i < RoadHolder.Count; i++)
        {
            var allChild = RoadHolder[i].GetComponentsInChildren<Transform>();

            for (int j = 0; j < allChild.Length; j++)
            {
                if (allChild[j].gameObject.tag == "Obstacle")
                {
                    AllObstacle.Add(allChild[j].gameObject);
                }
            }
        }

    }

    public void ShowObstacleOnStartClick()
    {
        if (RoadHolder.Count == 0) { RoadHolder = GetComponent<RaodRunSetup>().RoadHoder; }
        if (PlayerPostion == null) PlayerPostion = GameObject.FindGameObjectWithTag("Player").gameObject;

        if (RoadHolderMexPostion.Count == 0) 
        {
            for (int i = 0; i < RoadHolder.Count; i++)
            {
                RoadHolderMexPostion.Add(RoadHolder[i].transform.position.z);
            }
        }        
        var MinPoston  = RoadHolderMexPostion.Min();
        var minindex = -1;
        
        for (int i = 0; i < RoadHolderMexPostion.Count; i++)
        {
            if (MinPoston == RoadHolderMexPostion[i]) 
            {
                minindex = i;
            }
        }

        var IgnoreIndex = minindex;

        ShowObstacle(RoadHolder, IgnoreIndex);
        StartCoroutine(obstacleShowIgnore(RoadHolder, IgnoreIndex));
    }

   void ShowObstacle(List<GameObject> roadHolder, int ignoreIndex)
    {
        selectedObstacle .Clear();
        for (int i = 0; i < roadHolder.Count; i++)
        {
            Debug.Log(i + " ignoreIndex : " + ignoreIndex);
            if (i == ignoreIndex) continue;

            var allChild = roadHolder[i].GetComponentsInChildren<Transform>();

            for (int j = 0; j < allChild.Length; j++)
            {
                if (allChild[j].gameObject.tag == "Obstacle") 
                {
                    selectedObstacle.Add(allChild[j].gameObject);
                }
            }
        }

        for (int i = 0; i < selectedObstacle.Count; i++)
        {
            selectedObstacle[i].gameObject.GetComponent<obstacleActive>().SetobstacleActiveAndDeactive(true);
        }
    }

    IEnumerator obstacleShowIgnore(List<GameObject> roadHolder, int ignoreIndex)
    {
        ignoreObstacle.Clear();         
        var allChild = roadHolder[ignoreIndex].GetComponentsInChildren<Transform>();
        for (int i = 0; i < allChild.Length; i++)
        {
            if (allChild[i].gameObject.tag == "Obstacle")
            {
                ignoreObstacle.Add(allChild[i].gameObject);
            }
        }
        yield return new WaitForSeconds(10f);
        for (int i = 0; i < ignoreObstacle.Count; i++) { ignoreObstacle[i].gameObject.GetComponent<obstacleActive>().SetobstacleActiveAndDeactive(true); }
    }

   



}
