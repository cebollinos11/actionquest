using UnityEngine;
using System.Collections;

public class MoneyUp : SingleOptionEvent {

    int coins;

    void Awake() {
        coins = 5+Random.Range(1,20);
    }

    public override void PlaceIt(CanvasManager cM)
    {
        secondaryText = "You find "+coins.ToString()+" golden coins";
        base.PlaceIt(cM);
    }

    public override void OnReceive()
    {
        LevelManager.Instance.Player.GetComponent<PlayerController>().coins += coins;
        LevelManager.Instance.bui.UpdatePlayer();
    }

	

}
