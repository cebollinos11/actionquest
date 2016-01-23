using UnityEngine;
using System.Collections;

public class LevelUpEvent : SingleOptionEvent {


    public override void PlaceIt(CanvasManager cM)
    {
        secondaryText = "Your max. HP increases to: " + (LevelManager.Instance.Player.GetComponent<Actor>().maxHP + 1).ToString();
        base.PlaceIt(cM);
    }


    public override void OnReceive()
    {
        LevelManager.Instance.Player.GetComponent<Actor>().maxHP++;
        LevelManager.Instance.bui.UpdatePlayer();
    }

    

	
}
