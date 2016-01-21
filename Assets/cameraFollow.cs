using UnityEngine;
using System.Collections;

public class cameraFollow : MonoBehaviour {

    public Transform target;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;
    private float origZ;
    //public Vector3 fixedangle;
    public Vector3 offset;
    void Start()
    {
        origZ = transform.position.z;
        if (target == null)
        {
            target = LevelManager.Instance.Player.transform;
        }
    }
    void Update()
    {

        if (target == null) {
            return;
        }
        //transform.position =  target.position+offset;
        Vector3 tpos = target.position + offset;


        //normal follow
        //transform.position = tpos;
        //return;

        //smoothdamp
        //if (Vector3.Distance(transform.position, tpos) < 2.0)
        //    return;
        //Vector3 targetPosition = tpos;
        //transform.position = Vector3.SmoothDamp(transform.position, tpos, ref velocity, smoothTime);

        //lerp
        transform.position = Vector3.Lerp(transform.position, tpos, smoothTime);

      

        if (Input.GetKeyDown(KeyCode.I)) {

            offset = new Vector3(0, 40, -40);
            Camera.main.fieldOfView = 30f;
            
        }

        if (Input.GetKeyDown(KeyCode.O))
        {

            offset = new Vector3(0, 25, -25);
            Camera.main.fieldOfView = 60f;

        }
    
        


        
        
    }
}
