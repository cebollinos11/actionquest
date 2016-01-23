using UnityEngine;
using System.Collections;

public class HealUp : SingleOptionEvent {

    public override void OnReceive()
    {
        pC.currHP = pC.maxHP;
    }
}
