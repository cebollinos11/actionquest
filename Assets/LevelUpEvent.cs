using UnityEngine;
using System.Collections;

public class LevelUpEvent : SingleOptionEvent {


    public override void PlaceIt(CanvasManager cM)
    {
        secondaryText = "Your max. HP increases to: " + (LevelManager.Instance.Player.GetComponent<Actor>().maxHP + 2).ToString();
        base.PlaceIt(cM);
    }


    public override void OnReceive()
    {
        LevelManager.Instance.Player.GetComponent<Actor>().maxHP+=2;
        LevelManager.Instance.Player.GetComponent<Actor>().currHP += 2;
        LevelManager.Instance.bui.UpdatePlayer();
    }

    

	
}
