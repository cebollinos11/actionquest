using UnityEngine;
using System.Collections;

public class GoldCoins : ItemPickUp {










    public override void OnPickUp(Collision col)
    {
        base.OnPickUp(col);
        
        col.gameObject.GetComponent<PlayerController>().coins++;

    }
}
