using UnityEngine;
using System.Collections;

public class MagicHalo : MonoBehaviour {

    public float speed;

	
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(transform.parent.transform.position, Vector3.up, speed * Time.deltaTime);
	}
}
