using UnityEngine;
using System.Collections;

public class SingleOptionEvent :SpecialEvent {

    public override void PlaceIt(CanvasManager cM)
    {
        base.PlaceIt(cM);
        OnReceive();        
        cM.StartCoroutine(cM.DelayShowContinue());

    }
}
