using UnityEngine;
using System.Collections;

public class DoubleOptionEvent : SpecialEvent {

   
    public override void PlaceIt(CanvasManager cM)
    {
       
        cM.VisibilityOfTwoButtons(true);
        base.PlaceIt(cM);
    }

    public override void OnClick1()
    {
        base.OnClick1();
        
        PlaceIt(cM);
    }

    public override void OnClick2()
    {
        base.OnClick1();        
        PlaceIt(cM);
    }


}
