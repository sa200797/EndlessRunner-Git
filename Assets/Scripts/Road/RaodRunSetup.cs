
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using utilitys;

public class RaodRunSetup : MonoBehaviour
{
    [Space(20)]
    [SerializeField] int NumberOffTils;
    [SerializeField] GameObject RoadTilsPrefab;
    [SerializeField] List<GameObject> RoadHoder;
    [SerializeField] float speedZ;
    [SerializeField] float Offset;
    [SerializeField] float EndPotion;

    [SerializeField] GameObject ExchangeChange;

    void Start()
    {
        //roadSetup();
        setupRaods();
    }
    void Update()
    {
        if(PlayerManager.isGameStarted == true)
            roadRunSetup();
    }

    private void roadRunSetup()
    {
        for (int i = 0; i < RoadHoder.Count; i++)
        {
            int index = i;

            //if (RoadHoder.Any(index => index == null)) continue;
            if (RoadHoder[i] == null) continue;

            if (RoadHoder[index].transform.position.z < EndPotion)
            {
                ExchangeChange = RoadHoder[index].gameObject;
                ExchangeChange.SetActive(false);

                utility.Move(RoadHoder , index , RoadHoder.Count-1);

                int newIndex = RoadHoder.Count - 2;

                RoadHoder[RoadHoder.Count - 2].transform.position = new Vector3(
                    RoadHoder[RoadHoder.Count - 2].transform.position.x,
                    RoadHoder[RoadHoder.Count - 2].transform.position.y,
                    RoadHoder[newIndex-1].transform.position.z + Offset);

                ExchangeChange.SetActive(true);               

            }
            if (RoadHoder[index] != null)
                RoadHoder[i].transform.Translate(RoadHoder[index].transform.forward * -speedZ * Time.deltaTime, Space.World);
        }
    }
    #region Normal
    void setupRaods()
    {
        if (NumberOffTils != RoadHoder.Count) 
        {
            int availableTils = NumberOffTils - RoadHoder.Count;
            for (int i = 0; i < availableTils; i++)
            {
                GameObject RoadTile = Instantiate(RoadTilsPrefab, transform) as GameObject;
                RoadHoder.Add(RoadTile);
            }
            int TilsPoition = 0;
            for (int i = 0; i < RoadHoder.Count; i++)
            {
                RoadHoder[i].name = "Road" + i;
                RoadHoder[i].transform.position = new Vector3(RoadHoder[i].transform.position.x,RoadHoder[i].transform.position.y,RoadHoder[i].transform.position.z + TilsPoition);
                TilsPoition += 210;
            }
        }
    }

    #endregion
}