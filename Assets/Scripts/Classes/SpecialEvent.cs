using UnityEngine;
using System.Collections;

public class SpecialEvent : MonoBehaviour {

    

    
    public string mainText = "dio porco";
    public string secondaryText;
    public Sprite MainSprite;
    protected PlayerController pC;
    protected CanvasManager cM;
    public SpecialManager sM;

    


    public virtual void OnClick1() {
        cM.StartCoroutine(cM.DelayShowContinue());
    
    }

    public virtual void OnClick2() {

        cM.StartCoroutine(cM.DelayShowContinue());
    }
    

    public virtual void OnReceive()
    {
        
    }

    public virtual void PlaceIt(CanvasManager cMa) {
        pC = LevelManager.Instance.Player.GetComponent<PlayerController>();
        cM = cMa;
        cM.SetMainText(mainText);
        cM.SetSecondaryText(secondaryText);
        cM.SetMainImage(MainSprite);
    
    }


    protected void PlaySuccess() {
        sM.PlayClip(sM.successMusic);
        LevelManager.Instance.bui.UpdatePlayer();
    
    }

    protected void PlayFail() {
        sM.PlayClip(sM.failMusic);
        LevelManager.Instance.bui.UpdatePlayer();
    }

}
