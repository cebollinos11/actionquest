using UnityEngine;
using System.Collections;

public class ActionController : Singleton<ActionController> {

    cameraHandler camHandler;

	// Use this for initialization
	void Start () {
        StartCoroutine(Init());
	}

    IEnumerator Init(){
        yield return new WaitForSeconds(0.1f);
        camHandler = Camera.main.GetComponent<cameraHandler>();
    }


    public static void CamShake() {

        Instance.camHandler.ShakeCam();
    }
}
