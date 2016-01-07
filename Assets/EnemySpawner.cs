using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    GameObject toSpawn;
    
	// Use this for initialization
	void Start () {

        
	}

    public void SetToSpawn(GameObject what)
    {
     
        toSpawn = what;
        StartCoroutine(TimeToSpawn());
        
    }

    IEnumerator TimeToSpawn() {
        yield return new WaitForSeconds(0.5f);
        Instantiate(toSpawn, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
