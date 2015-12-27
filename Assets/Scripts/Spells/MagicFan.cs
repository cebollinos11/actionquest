using UnityEngine;
using System.Collections;

public class MagicFan : Spell {

 

    public override void Cast(GameObject owner1, Vector3 direction1)
    {
        base.Cast(owner1, direction1);

        GameObject go = (GameObject)Instantiate(toInstantiate, transform.position, transform.rotation);

        MagicFanInstance mfi = go.GetComponent<MagicFanInstance>();

        mfi.owner = owner1;
        mfi.direction = direction1;
        mfi.Run(owner1,direction1);

        owner1.GetComponent<Actor>().BlockMove(0.5f);
        


        


    }
}
