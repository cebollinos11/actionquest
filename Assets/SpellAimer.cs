using UnityEngine;
using System.Collections;

public class SpellAimer : MonoBehaviour {


    PlayerController player;

	// Use this for initialization
	void Start () {
        player = GetComponentInParent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {

        transform.rotation = Quaternion.Euler(new Vector3(90, Mathf.Atan2(player.lastDirection.x, player.lastDirection.z) * Mathf.Rad2Deg , 0));
        Debug.Log(player.lastDirection);         
	
	}

    public void turnOn(bool onOrOff){
        if (onOrOff) {
            gameObject.SetActive(true);
        }

        else{
            gameObject.SetActive(false);
        }
    }
}
