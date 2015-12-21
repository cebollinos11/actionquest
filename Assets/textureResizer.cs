using UnityEngine;
using System.Collections;

public class textureResizer : MonoBehaviour {

    public int ratio = 1;

	// Use this for initialization
	void Start () {

        MeshRenderer me = GetComponent<MeshRenderer>();

        me.material.mainTextureScale = new Vector2(transform.lossyScale.x/ratio, transform.lossyScale.z/ratio);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
