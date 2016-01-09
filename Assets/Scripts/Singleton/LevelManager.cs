using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : Singleton<LevelManager> {

    


    public bool alreadyInitialized;
    public int currentLevel;
    [HideInInspector]public GameObject Player;

    [HideInInspector]public List<GameObject> EnemyDB;
    [HideInInspector]
    public List<GameObject> BossDB;
    [HideInInspector]
    public List<GameObject> RoomDB;
    [HideInInspector]
    public List<GameObject> LootDB;

    [HideInInspector]
    public BattleUI bui;

    public RoomManager currentRoom;


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



        GameObject battleUI = (GameObject)Resources.Load("Prefabs/BattleUI");
        GameObject bUI = (GameObject)Instantiate(battleUI, Vector3.zero, Quaternion.identity);
        bUI.transform.parent = Instance.transform;

        Instance.bui = bUI.GetComponent<BattleUI>();

        



        //init enemies
        //Debug.Log("start loading");
        //Instance.EnemyDB = (GameObject[])Resources.LoadAll("Prefabs/Enemies",typeof(GameObject));
        //Debug.Log(Instance.EnemyDB);

        foreach (GameObject g in Resources.LoadAll("Prefabs/Enemies", typeof(GameObject)))
        {
            
            Instance.EnemyDB.Add(g);
        }

        foreach (GameObject g in Resources.LoadAll("Prefabs/Bosses", typeof(GameObject)))
        {
            
            Instance.BossDB.Add(g);
        }

        foreach (GameObject g in Resources.LoadAll("Prefabs/Loot", typeof(GameObject)))
        {
            
            Instance.LootDB.Add(g);
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

    public static GameObject ReturnLoot() {

        GameObject loot = Instance.LootDB[Random.Range(0, Instance.LootDB.Count)];
        return loot;
    
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

    public void LoadTestLevel() {

        GameObject map = (GameObject)Resources.Load("Prefabs/TestRoom");
        GameObject instantiatedMap = (GameObject)Instantiate(map, Vector3.zero, Quaternion.Euler(0, Random.Range(0, 2) * (-45), 0));
        
    }

    public void LoadLevel()
    {



        Debug.Log("Loading level " + currentLevel.ToString());
        //GameObject map = (GameObject)Resources.Load("Prefabs/Rooms/Map");

        GameObject map = Instance.RoomDB[Random.Range(0, Instance.RoomDB.Count)];
        GameObject instantiatedMap = (GameObject)Instantiate(map, Vector3.zero, Quaternion.Euler(0, Random.Range(0,2)*(-45), 0));
        instantiatedMap.GetComponent<RoomManager>().Init(currentLevel%3==0);
        //instantiatedMap.GetComponent<RoomManager>().Init(true);

        currentRoom = instantiatedMap.GetComponent<RoomManager>();


        

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
