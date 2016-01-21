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
        if (1 > 2)
        {

            cM.MainText.text = "You level up!";
            LevelManager.Instance.Player.GetComponent<Actor>().maxHP += 1;
            LevelManager.Instance.bui.UpdatePlayer();
            StartCoroutine(EnableExit());
        }

        else { 
        
        }
        
    
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
