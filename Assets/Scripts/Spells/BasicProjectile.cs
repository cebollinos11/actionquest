using UnityEngine;
using System.Collections;

public class BasicProjectile : Spell {

    string name = "basic projectileeee";

   

    public override void Cast(GameObject owner, Vector3 direction)
    {
        base.Cast(owner, direction);
        GameObject go = (GameObject)Instantiate(toInstantiate, owner.transform.position + Vector3.up, owner.transform.rotation);
        Projectile pj = go.GetComponent<Projectile>();
        pj.InitProjectile(direction, owner.gameObject.tag);
        //pj.direction = direction;
        //pj.tag = owner.gameObject.tag;
    }
}
