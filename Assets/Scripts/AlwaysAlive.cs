using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysAlive : MonoBehaviour
{
    public AlwaysAlive instance;

    [SerializeField]
     Vector3 initialPosition;

    GameObject player;
    [SerializeField]
    private float distance = 0.05f;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");   }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            if (Vector3.Distance(transform.position, Vector3.zero) < distance)
            {
              
                transform.position = initialPosition;
            }
        }
        else
        {
            return;
        }
    }
}
