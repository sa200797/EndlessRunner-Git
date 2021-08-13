using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFloor : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    [SerializeField]
    private Transform playerTransform;
    [SerializeField]
    private float spawnZ = -35.0f;
    [SerializeField]
    private float tileLength = 30f;
    [SerializeField]
    private int amnTilesOnScreen = 10;
    [SerializeField]
    private float safeZone = 9.0f;
    [SerializeField]
    private List<GameObject> activeTiles;

    public float forwardSpeed;
    // Start is called before the first frame update



    void Start()
    {
        activeTiles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i = 0; i < amnTilesOnScreen; i++)
        {
            SpawnTile();
          
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z - safeZone > (spawnZ - amnTilesOnScreen * tileLength))
        {
            SpawnTile();
            DeleteTile();
        }
    }
    private void SpawnTile(int prefabIndex = -1)
    {
        GameObject go;
        go = Instantiate(tilePrefabs[0]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        activeTiles.Add(go);
    }
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    void MoveTiles()
    {
       

    }
}

