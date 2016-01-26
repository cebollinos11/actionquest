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
    public List<GameObject> WeaponDB;
    [HideInInspector]
    public List<GameObject> SpecialEventsDB;

    [HideInInspector]
    public BattleUI bui;

    public RoomManager currentRoom;


    public static void RestartGame() {
        Instance.currentLevel = 0;
        GameObject player = (GameObject)Resources.Load("Prefabs/Player");
        Instance.Player = Instantiate(player, Vector3.zero, Quaternion.identity) as GameObject;
        Instance.Player.gameObject.name = "Player";
        Destroy(Instance.gameObject);
    }

    static void Init() {

        Instance.alreadyInitialized = true;
        DontDestroyOnLoad(Instance.transform.gameObject);
        
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


        GameObject generalUI = (GameObject)Resources.Load("Prefabs/GeneralUI");
        GameObject gUI = (GameObject) Instantiate(generalUI, Vector3.zero, Quaternion.identity);
        gUI.transform.parent = Instance.transform;
        



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

        foreach (GameObject g in Resources.LoadAll("Prefabs/Weapons", typeof(GameObject)))
        {

            Instance.WeaponDB.Add(g);
        }

        foreach (GameObject g in Resources.LoadAll("Prefabs/Loot", typeof(GameObject)))
        {
            
            Instance.LootDB.Add(g);
        }

        foreach (GameObject g in Resources.LoadAll("Prefabs/SpecialEvents", typeof(GameObject)))
        {

            Instance.SpecialEventsDB.Add(g);
        }

        foreach (GameObject g in Resources.LoadAll("Prefabs/Rooms", typeof(GameObject)))
        {
            
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

   

    public void LoadLevel()
    {



        

        


        //GameObject map = (GameObject)Resources.Load("Prefabs/Rooms/Map");

        GameObject map = Instance.RoomDB[Random.Range(0, Instance.RoomDB.Count)];
        GameObject instantiatedMap = (GameObject)Instantiate(map);
        instantiatedMap.GetComponent<RoomManager>().Init(currentLevel%3==0);
        //instantiatedMap.GetComponent<RoomManager>().Init(true);
        currentRoom = instantiatedMap.GetComponent<RoomManager>();
        Camera.main.GetComponent<cameraHandler>().ZoomOut();
        
        
        

        
        
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.X)) {
            FinishLevel();
        }
    }



    public static void FinishLevel() {

        Debug.Log("Go to next level!");

        SavePlayer();



        LevelManager.Instance.Player.GetComponent<PlayerController>().enabled = false;
        LevelManager.Instance.Player.GetComponent<Rigidbody>().isKinematic = true;

        Application.LoadLevel("special");
        
    }

    public static void LoadNextLevel() {
          
        Instance.currentLevel++;
        LevelManager.Instance.Player.GetComponent<PlayerController>().enabled = true;
        LevelManager.Instance.Player.GetComponent<Rigidbody>().isKinematic = false;
        
        Application.LoadLevel("game");
    }

    public void PlayerDied() {
        DisableEnemies();
        StartCoroutine(GoToMainMenu());

    
    }
    IEnumerator GoToMainMenu()
    {


        yield return new WaitForSeconds(5f);

        Application.LoadLevel("title");
        LevelManager.RestartGame();

    }

    public void DisableEnemies() {

        Enemy[] enemyList = GameObject.FindObjectsOfType<Enemy>();

        for (int i = 0; i < enemyList.Length; i++)

        {
            enemyList[i].enabled = false;
        }
        
    
    }

	
	
}
