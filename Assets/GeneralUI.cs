using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GeneralUI : Singleton<GeneralUI>{

    public GameObject MainText;

	// Use this for initialization
	void Start () {

        MainText.SetActive(false);
	
	}


    public void ShowMessage(string msg) {

        MainText.SetActive(true);
        MainText.GetComponent<Text>().text = msg;
        StartCoroutine(TurnOfMainTextIn());
        
        
    }

    IEnumerator TurnOfMainTextIn() {
        yield return new WaitForSeconds(2.5f);
        MainText.SetActive(false);
    }


}
