using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindCamera : MonoBehaviour
{
    [SerializeField]
    Vector3 postionC;

    public Transform position;

    public GameObject child;

    // Start is called before the first frame update
    private void Awake()
    {

        child = GameObject.FindGameObjectWithTag("Jio");
    }


    void Start()
    {
        move(postionC);
        child.transform.SetParent(position,false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void move(Vector3 position)
    {
        this.transform.position = position;
    }
}
