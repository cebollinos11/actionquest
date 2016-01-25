using UnityEngine;
using System.Collections;


public class SpecialManager : MonoBehaviour {

    CanvasManager cM;
    SpecialEvent sE;
    
    bool exitEnabled = false;

	// Use this for initialization
	void Start () {

        cM = GetComponent<CanvasManager>();        
        Roll();
	
	}

    public void ClickedContinue() {

        cM.ContinueButton.enabled = false;
        Exit();
    }

    //public virtual void EffectOnClick1() { 
    
    //}

    //public virtual void EffectOnClick2()
    //{

    //}

    void Roll()
    {

        //if (Random.Range(1, 100) > 50)
        //{
        //    cM.MainText.text = "";
        //    cM.SetMainImage(LevelManager.Instance.Player.GetComponent<PlayerActor>().sH.GetComponent<SpriteRenderer>().sprite);
        //    StartCoroutine(EnableExit());
        //    return;        
        //}



        //if (Random.Range(1,100)>50)
        //{
        //    cM.MainText.text = "You level up!";
        //    LevelManager.Instance.Player.GetComponent<Actor>().maxHP += 1;
        //    LevelManager.Instance.bui.UpdatePlayer();
            
        //}

        //else {

        //    cM.MainText.text = "You find a new weapon";
        //    GameObject newWeapon =  LevelManager.Instance.WeaponDB[Random.Range(0, LevelManager.Instance.WeaponDB.Count)];
        //    Weapon newWeaponScript = newWeapon.GetComponent<Weapon>();
        //    cM.SetMainImage(newWeaponScript.sprite);
        //    LevelManager.Instance.Player.GetComponent<PlayerActor>().equippedWeapon = newWeaponScript;
        //    if (newWeaponScript == null) {
               
        //        Debug.Log(newWeapon.name);
        //    }


        
        //}

        //StartCoroutine(EnableExit());

        GameObject sEobject = (GameObject)Resources.Load("Prefabs/SpecialEvents/FountainEvent");
        GameObject sEGobject = Instantiate(sEobject) as GameObject;
        sE = sEGobject.GetComponent<SpecialEvent>();
        sE.PlaceIt(cM);


    }

    public  void Option1Clicked() {
        sE.OnClick1();
        cM.VisibilityOfTwoButtons(false);
        
        
    }

    public  void Option2Clicked() {
        sE.OnClick2();
        cM.VisibilityOfTwoButtons(false);

    }

    IEnumerator EnableExit() {
        yield return new WaitForSeconds(1f);
        exitEnabled = true;
        cM.ExitText.enabled = true;
    }

	// Update is called once per frame
	void Update () {

        if (exitEnabled && (Input.GetButtonDown("AttackW") ||Input.GetButtonDown("AttackE") ||Input.GetButtonDown("AttackN") ||Input.GetButtonDown("AttackS")))
        {
            Exit();
        }
	}

    public void Exit()
    {

        LevelManager.LoadNextLevel();
    }
}
