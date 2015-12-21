using UnityEngine;
using System.Collections;

public class autodestruct : MonoBehaviour {

    [SerializeField]
    float seconds;

	// Use this for initialization
	
	
	// Update is called once per frame
	void Update () {

        seconds -= Time.deltaTime;

        if (seconds < 0) {
            AutoDestroy();
        
        }
	}

    void AutoDestroy()
    {
        Destroy(gameObject);
    
    }
}
