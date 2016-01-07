using UnityEngine;
using System.Collections;

public class SingletonHandler : MonoBehaviour {

    public GameObject LvlMng;

	// Use this for initialization
	void Start () {
        int number = 0;
        foreach (var gameObj in FindObjectsOfType(typeof(GameObject)) as GameObject[])
        {
            if (gameObj.name == LvlMng.name)
            {
                number++;
                
            }
        }

        if (number == 0)
        {

            GameObject lvlm = (GameObject)Instantiate(LvlMng, Vector3.zero, Quaternion.identity);
            lvlm.name = LvlMng.name;

        }

        else {
            LevelManager.Instance.LoadLevel();
        }
       
	
	}
	
	
}
