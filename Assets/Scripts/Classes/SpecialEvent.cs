using UnityEngine;
using System.Collections;

public class SpecialEvent : MonoBehaviour {

    

    
    public string mainText = "dio porco";
    public string secondaryText;
    public Sprite MainSprite;
    protected PlayerController pC;

    

    public virtual void OnReceive()
    {
        
    }

    public virtual void PlaceIt(CanvasManager cM) {
        pC = LevelManager.Instance.Player.GetComponent<PlayerController>();
        cM.SetMainText(mainText);
        cM.SetSecondaryText(secondaryText);
        cM.SetMainImage(MainSprite);
    
    }

    // Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
