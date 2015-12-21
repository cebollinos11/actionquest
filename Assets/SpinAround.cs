using UnityEngine;
using System.Collections;

public class SpinAround : MonoBehaviour {

    float speed = 10f;
	// Use this for initialization
	
	
	// Update is called once per frame
	void Update () {

        //transform.RotateAroundLocal(Vector3.forward, speed * Time.timeScale);

        transform.Rotate(Vector3.forward, speed * Time.timeScale);
	
	}
}
