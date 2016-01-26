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


        GameObject sEobject = (GameObject)Resources.Load("Prefabs/SpecialEvents/TransformMage");

        sEobject = LevelManager.Instance.SpecialEventsDB[Random.Range(0, LevelManager.Instance.SpecialEventsDB.Count)];        

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
