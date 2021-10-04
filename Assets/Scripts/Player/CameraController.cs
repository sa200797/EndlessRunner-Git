using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    private Transform target;  
    private Vector3 offset;
    
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - target.position;

    }


    private void Update()
    {
        if(target == null)
        {
          //  this.target.transform.position = new Vector3(0f, 3.95f, -10f);
            target = GameObject.FindGameObjectWithTag("Player").transform;
            offset = transform.position - target.position;
        }
    }
    void LateUpdate()
    {
       
        if(target != null )
        {
            Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, offset.z + target.position.z);
            transform.position = Vector3.Lerp(transform.position, newPosition, 0.6f);
        }
        

               
            
        
    }
}
