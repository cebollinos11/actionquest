using UnityEngine;
using System.Collections;

public class cameraFollow : MonoBehaviour {

    public Transform target;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;
    private float origZ;
    public Vector3 fixedangle;
    public Vector3 offset;
    void Start()
    {
        origZ = transform.position.z;
    }
    void Update()
    {
        
        
        transform.position =  target.position+offset;
        //transform.position = new Vector3(transform.position.x, transform.position.y, origZ);
        
    }
}
