using UnityEngine;
using System.Collections;

public class TransformMage : DoubleOptionEvent {

    public Sprite princeSprite;


    public override void OnClick1()
    {
        if (Random.Range(0, 100) < 0)
        {
            
            secondaryText = "Ewww! Kissing a frog? You lose 1 hp";
            pC.TakeNonLethalDamage(1);
            PlayFail();

        }

        else
        {
            int coins = 20;
            MainSprite = princeSprite;
            mainText = "The frog turns into a princess!";
            secondaryText = "Thanks for breaking the curse! Take this money, you can use it to take some make out lessons. "+coins.ToString()+" added to the inventory";
            pC.coins += coins;
            //LevelManager.Instance.Player.GetComponent<Actor>().sH.GetComponent<SpriteRenderer>().sprite = MainSprite;
            PlaySuccess();

        }
        
        
        base.OnClick1();
    }

    public override void OnClick2()
    {

        if (Random.Range(0, 100) < 50)
        {
            mainText = "";
            secondaryText = "I guess this frog ain't getting any tonight";

        }

        else {

            mainText = "The frog curses you!";
            secondaryText = "The frog says: \"Now you will see what it is to be a ugly ass frog!!\"";
            LevelManager.Instance.Player.GetComponent<Actor>().sH.GetComponent<SpriteRenderer>().sprite = MainSprite;
            PlayFail();
        
        }

        base.OnClick2();
    }

	
}
