using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleShow : MonoBehaviour
{
    [SerializeField] List<GameObject> RoadHolder;
    [SerializeField] List<float> roadDistances;

    [SerializeField] List<GameObject> AllObstacle;
    [SerializeField] List<GameObject> selectedObstacle;
    
    void Start()
    {
        HideAll();
    }


    void ShowAll()
    {
        if (AllObstacle.Count == 0)
        {
            Debug.Log("Object not fill");
            OnStartSetupObstaleCall();
            return;
        }
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
            OnStartSetupObstaleCall();
            return;
        }
        for (int i = 0; i < AllObstacle.Count; i++)
            AllObstacle[i].gameObject.GetComponent<obstacleActive>().SetobstacleActiveAndDeactive(false);


    }

    void OnStartSetupObstaleCall()
    {
        var allChild = transform.GetComponentsInChildren<Transform>();

        for (int i = 0; i < allChild.Length; i++)
        {
            if (allChild[i].gameObject.tag == "Obstacle")
            {
                AllObstacle.Add(allChild[i].gameObject);
            }
        }
    }

}
