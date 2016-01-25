using UnityEngine;
using System.Collections;

public class ShoesEvent : DoubleOptionEvent {

    public Sprite[] multiSprite;

    void Awake() { 
        MainSprite = multiSprite[Random.Range(0,multiSprite.Length-1)];
    }

    public override void OnClick1()
    {


        int die = Random.Range(1, 100);
        mainText = "";

        if (die < 40) {
            
            secondaryText = "You look amazing on those babies! Self-confidence increased!";
        }

        else if(die<75){
            pC.IDmaxSpeed(1);
            secondaryText = "Those were magic boots! Speed increased to "+pC.maxSpeed.ToString()+ "!";
            
        
        
        }

        else if (die < 101)
        {
            pC.IDmaxSpeed(-1);
            secondaryText = "Those boots are too heavy! Speed decreased to " + pC.maxSpeed.ToString() + "!";
        
        }
        
        base.OnClick1();
        
    }

    public override void OnClick2()
    {

        mainText = "";
        secondaryText = "\"I would never wear those ugly ass boots\"";
        base.OnClick2();
    }

}
