﻿using UnityEngine;
using System.Collections;

public class billboardSC : MonoBehaviour {

	
	
	// Update is called once per frame
	void Update () {

        transform.LookAt(Camera.main.transform.position, Vector3.up);
	
	}
}
