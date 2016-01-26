using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class SpecialManager : MonoBehaviour {

    CanvasManager cM;
    SpecialEvent sE;
    
    bool exitEnabled = false;

    public AudioClip[] tensionMusic;
    public AudioClip[] successMusic;
    public AudioClip[] failMusic;
    AudioSource aSource;


    public void PlayClip(AudioClip[] ac) {
        

        AudioClip toplay = ac[Random.Range(0,ac.Length)];
        aSource.clip = toplay;
        aSource.Play();
    
    }

	// Use this for initialization
	void Start () {
        aSource = GetComponent<AudioSource>();
        cM = GetComponent<CanvasManager>();
        PlayClip(tensionMusic);
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


        GameObject sEobject;

        LevelManager.Instance.specialEventIndex++;
        if (LevelManager.Instance.specialEventIndex > LevelManager.Instance.SpecialEventsDB.Count - 1) {
            LevelManager.Instance.specialEventIndex = 0;
            LevelManager.Instance.ShuffleSpecial();
        }
            

        sEobject = LevelManager.Instance.SpecialEventsDB[LevelManager.Instance.specialEventIndex];

        //sEobject = (GameObject)Resources.Load("Prefabs/SpecialEvents/TransformMage");

        GameObject sEGobject = Instantiate(sEobject) as GameObject;
        sE = sEGobject.GetComponent<SpecialEvent>();
        sE.sM = this;
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
