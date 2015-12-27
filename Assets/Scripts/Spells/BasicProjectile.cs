using UnityEngine;
using System.Collections;

public class BasicProjectile : Spell {

    string name = "basic projectileeee";

	// Use this for initialization
	void Start () {
        
	}

    public override void Cast(GameObject owner, Vector3 direction)
    {
        base.Cast(owner, direction);
        GameObject go = (GameObject)Instantiate(toInstantiate, owner.transform.position + Vector3.up, owner.transform.rotation);
        Projectile pj = go.GetComponent<Projectile>();
        pj.direction = direction;
        pj.tag = owner.gameObject.tag;
    }
}
