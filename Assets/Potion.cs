using UnityEngine;
using System.Collections;

public class Potion : ItemPickUp {

    public bool health;
    public bool mana;

    public override void OnPickUp(Collision col)
    {
        base.OnPickUp(col);
        if (health)
        {
            col.gameObject.GetComponent<PlayerController>().HealDamage(1f);
            //GeneralUI.Instance.ShowMessage("+1 HP");
        }

        
    }
}
