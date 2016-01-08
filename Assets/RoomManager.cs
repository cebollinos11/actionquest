using UnityEngine;
using System.Collections;

public class RoomManager : MonoBehaviour {

    public GameObject playerSpawn;
    public GameObject[] enemySpawners;

    GameObject spawner;

	// Use this for initialization
	void Start () {

        spawner = Resources.Load("Prefabs/EnemySpawner") as GameObject;
        PlaceObjects();
        LevelManager.Instance.bui.UpdatePlayer();
	
	}

    public void PlaceObjects() {

        LevelManager.Instance.Player.transform.position = playerSpawn.transform.position;
        Debug.Log("room started");

        //enemies
        int nEnemies = LevelManager.Instance.currentLevel*2;
        
        //GameObject enemy = LevelManager.Instance.EnemyDB[1];
        for (int i = 0; i < nEnemies; i++)
        {

            GameObject enemy = LevelManager.Instance.EnemyDB[Random.Range(0, LevelManager.Instance.EnemyDB.Count)];
            GameObject cube = enemySpawners[Random.Range(0, enemySpawners.Length)];
            float x = Random.Range(-cube.transform.localScale.x / 2f,  cube.transform.localScale.x / 2f);
            float z = Random.Range(-cube.transform.localScale.z / 2f, cube.transform.localScale.z / 2f);
            //Vector3 position= new Vector3(Random.value * cube.transform.position.x, Random.value * cube.transform.position.y, Random.value * cube.transform.position.y);
            GameObject spw = (GameObject) Instantiate(spawner,cube.transform.position,transform.rotation);
            
            //move it
            spw.transform.Translate(x, 0f, z, Space.Self);
            spw.GetComponent<EnemySpawner>().SetToSpawn(enemy);
            


        }

        //once finished, destroy the EnemySpawners
        for (int i = 0; i < enemySpawners.Length; i++)
        {
            Destroy(enemySpawners[i]);
        }
    }
}
