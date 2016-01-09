using UnityEngine;
using System.Collections;

public class MagicFan : Spell {

 

    public override void Cast(GameObject owner1, Vector3 direction1)
    {
        base.Cast(owner1, direction1);

        Debug.Log(owner1.transform.localScale.y + (owner1.transform.position - Vector3.up * owner1.transform.localScale.y).ToString());
        GameObject go = (GameObject)Instantiate(toInstantiate, owner1.transform.position -Vector3.up*owner1.transform.localScale.y + Vector3.up, owner1.transform.rotation);

        MagicFanInstance mfi = go.GetComponent<MagicFanInstance>();

        mfi.owner = owner1;
        mfi.direction = direction1;
        mfi.Run(owner1,direction1);

             


    }
}
