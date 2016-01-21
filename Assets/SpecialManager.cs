using UnityEngine;
using System.Collections;


public class SpecialManager : MonoBehaviour {

    CanvasManager cM;

    bool exitEnabled = false;

	// Use this for initialization
	void Start () {

        cM = GetComponent<CanvasManager>();


        
        Roll();
	
	}

    void Roll()
    {
        if (Random.Range(1,100)>50)
        {

            cM.MainText.text = "You level up!";
            LevelManager.Instance.Player.GetComponent<Actor>().maxHP += 1;
            LevelManager.Instance.bui.UpdatePlayer();
            
        }

        else {

            cM.MainText.text = "You find a new weapon";
            GameObject newWeapon =  LevelManager.Instance.WeaponDB[Random.Range(0, LevelManager.Instance.WeaponDB.Count)];
            Weapon newWeaponScript = newWeapon.GetComponent<Weapon>();
            cM.SetMainImage(newWeaponScript.sprite);
            LevelManager.Instance.Player.GetComponent<PlayerActor>().equippedWeapon = newWeaponScript;
            if (newWeaponScript == null) {
                Debug.Log("Problems here");
                Debug.Log(newWeapon.name);
            }


        
        }

        StartCoroutine(EnableExit());
    }

    IEnumerator EnableExit() {
        yield return new WaitForSeconds(1f);
        exitEnabled = true;
        cM.ExitText.enabled = true;
    }

	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Jump") && exitEnabled)
        {
            Exit();
        }
	}

    public void Exit()
    {

        LevelManager.LoadNextLevel();
    }
}
