using UnityEngine;
using System.Collections;

public class LevelManager : Singleton<LevelManager> {

    public bool alreadyInitialized;
    int currentLevel;
    [HideInInspector]public GameObject Player;


    static void Init() {

        Instance.alreadyInitialized = true;
        DontDestroyOnLoad(Instance.transform.gameObject);
        Debug.Log("Initializing levelmanager");
        Instance.currentLevel = 0;



        GameObject player = (GameObject)Resources.Load("Prefabs/Player");
        Instance.Player = Instantiate(player, Vector3.zero, Quaternion.identity) as GameObject;
        Instance.Player.gameObject.name = "Player";


        GameObject gameController = (GameObject)Resources.Load("Prefabs/GameController");
        GameObject gcon = (GameObject)Instantiate(gameController, Vector3.zero, Quaternion.identity);
        gcon.transform.parent = Instance.transform;

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
        GameObject map = (GameObject)Resources.Load("Prefabs/Rooms/Map");
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
        SavePlayer();        
        //Camera.main.GetComponent<cameraHandler>().ZoomIn();
        Application.LoadLevel("game");
        
    }

	
	
}
