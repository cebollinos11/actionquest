using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : Singleton<LevelManager> {

    public bool alreadyInitialized;
    public int currentLevel;
    [HideInInspector]public GameObject Player;

    [HideInInspector]public List<GameObject> EnemyDB;
    [HideInInspector]
    public List<GameObject> RoomDB;


    static void Init() {

        Instance.alreadyInitialized = true;
        DontDestroyOnLoad(Instance.transform.gameObject);
        Debug.Log("Initializing levelmanager");
        Instance.currentLevel = 1;



        GameObject player = (GameObject)Resources.Load("Prefabs/Player");
        Instance.Player = Instantiate(player, Vector3.zero, Quaternion.identity) as GameObject;
        Instance.Player.gameObject.name = "Player";


        GameObject gameController = (GameObject)Resources.Load("Prefabs/GameController");
        GameObject gcon = (GameObject)Instantiate(gameController, Vector3.zero, Quaternion.identity);
        gcon.transform.parent = Instance.transform;

        //init enemies
        //Debug.Log("start loading");
        //Instance.EnemyDB = (GameObject[])Resources.LoadAll("Prefabs/Enemies",typeof(GameObject));
        //Debug.Log(Instance.EnemyDB);

        foreach (GameObject g in Resources.LoadAll("Prefabs/Enemies", typeof(GameObject)))
        {
            Debug.Log("prefab found: " + g.name);
            Instance.EnemyDB.Add(g);
        }

        foreach (GameObject g in Resources.LoadAll("Prefabs/Rooms", typeof(GameObject)))
        {
            Debug.Log("prefab found: " + g.name);
            Instance.RoomDB.Add(g);
        }

        Instance.LoadLevel();
        
    }

    static void SavePlayer() {

        DontDestroyOnLoad(Instance.Player);
        Instance.Player = GameObject.Find("Player");
        //Instance.Player.GetComponent<Rigidbody>().isKinematic = true;
    
    }


	// Use this for initialization
	void Start () {

        Debug.Log("reality check " + Instance.alreadyInitialized);
        if (Instance.alreadyInitialized) { }

        if (Instance.alreadyInitialized == false)
        { 
            Init();
        }

        
        
	
	}

    public void LoadLevel()
    {



        Debug.Log("Loading level " + currentLevel.ToString());
        //GameObject map = (GameObject)Resources.Load("Prefabs/Rooms/Map");

        GameObject map = Instance.RoomDB[Random.Range(0, Instance.RoomDB.Count)];
        Instantiate(map, Vector3.zero, Quaternion.Euler(0, -45, 0));
        Debug.Log("Finish loading");
        
        

        
        
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.X)) {
            FinishLevel();
        }
    }

    public static void FinishLevel() {

        Debug.Log("Go to next level!");
        Instance.currentLevel++;
        SavePlayer();        
        //Camera.main.GetComponent<cameraHandler>().ZoomIn();
        Application.LoadLevel("game");
        
    }

	
	
}
