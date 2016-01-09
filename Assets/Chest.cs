using UnityEngine;
using System.Collections;

public class Chest : ItemPickUp {

    public override void OnPickUp(Collision col)
    {
        base.OnPickUp(col);

        for (int i = 0; i < 5; i++)
        {
            GameObject loot = LevelManager.ReturnLoot();
            Instantiate(loot, transform.position+new Vector3(Random.Range(-1.0F, 1.0F), 0, Random.Range(-1f,1F)), Quaternion.identity);
        }
    }
}
