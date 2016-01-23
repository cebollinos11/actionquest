using UnityEngine;
using System.Collections;

public class doorScript : MonoBehaviour {

    public Sprite spriteClosed;
    public Sprite spriteOpen;

    public GameObject doorSprite;

    public GameObject Text;

    SphereCollider sphereCol;
    bool insideSphere;

    bool opened;

    

	// Use this for initialization
	void Start () {

        Text.gameObject.SetActive(false);
        sphereCol = GetComponent<SphereCollider>();
        sphereCol.enabled = false;
        
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Q)) {

            Open();

        }

        if (opened && insideSphere && (Input.GetButtonDown("AttackW") ||Input.GetButtonDown("AttackE") ||Input.GetButtonDown("AttackN") ||Input.GetButtonDown("AttackS")  ))
        {
            enabled = false;
            StartCoroutine(TransitionToNextLevel());
        }
	
	}

    IEnumerator TransitionToNextLevel() {

        Camera.main.GetComponent<cameraHandler>().ZoomIn();
        //Camera.main.GetComponent<cameraHandler>().FadeOut();
        yield return new WaitForSeconds(1f);
        LevelManager.FinishLevel();
        //Camera.main.GetComponent<cameraHandler>().ZoomOut();
    }

    public void Open() {

        doorSprite.GetComponent<SpriteRenderer>().sprite = spriteOpen;        
        opened = true;
        sphereCol.enabled = true;
        
    }

    public void Close() {

        doorSprite.GetComponent<SpriteRenderer>().sprite = spriteClosed;
        opened = false;
        sphereCol.enabled = false;
        
    }

    void OnTriggerEnter(Collider col)
    {

//Debug.Log("collision with " + col.gameObject.ToString());
        if (col.gameObject.name == "Player")
        {
            Text.SetActive(true);
            insideSphere = true;
        }
    
    }


    void OnTriggerExit(Collider col)
    {

        Debug.Log("collision with " + col.gameObject.ToString());
        if (col.gameObject.name == "Player")
        {
            Text.SetActive(false);
            insideSphere = false;
        }

    }
}
