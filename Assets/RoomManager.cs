using UnityEngine;
using System.Collections;

public class RoomManager : MonoBehaviour {

    public GameObject playerSpawn;

	// Use this for initialization
	void Start () {

        
        PlaceObjects();
	
	}

    public void PlaceObjects() {

        LevelManager.Instance.Player.transform.position = playerSpawn.transform.position;
        Debug.Log("room started");
    }
}
