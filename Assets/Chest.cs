using UnityEngine;
using System.Collections;

public class Chest : ItemPickUp {

    public override void OnPickUp(Collision col)
    {
        base.OnPickUp(col);

        for (int i = 0; i < 5; i++)
        {
            GameObject loot = LevelManager.ReturnLoot();
            Instantiate(loot, transform.position+new Vector3(Random.Range(-2.0F, 2.0F), 0, Random.Range(-2f,2F)), Quaternion.identity);
            //Instantiate(loot, transform.position + Vector3.up*(i), Quaternion.identity);
        }
    }
}
