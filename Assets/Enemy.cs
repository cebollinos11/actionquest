using UnityEngine;
using System.Collections;

public class Enemy : Actor {

	// Use this for initialization
	void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void TakeDamage(int dmg, Vector3 direction) {
        base.TakeDamage(dmg, direction);
        Debug.Log("rat jumps");
        if(rB.velocity.y==0f)
            rB.velocity += new Vector3(0, 10f, 0);


        Debug.Log(rB.velocity);
    
    }
}
