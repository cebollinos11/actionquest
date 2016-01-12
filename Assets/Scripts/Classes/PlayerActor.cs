using UnityEngine;
using System.Collections;

public class PlayerActor : SpellCaster
{

    public GameObject StartingWeapon;
    [HideInInspector]public Weapon equippedWeapon;

    bool canThrow = true;

    public void Start() {

        Debug.Log("player actor init");
        base.Start();
        equippedWeapon = StartingWeapon.GetComponent<Weapon>();
    }


    IEnumerator EnableCanThrowIn(float cooldown)
    {
        canThrow = false;
        yield return new WaitForSeconds(cooldown);
        canThrow = true;
    }

   public void Throw(Vector3 direction)
    {

        if (!canThrow) {
            Debug.Log("cant throw nigga!");
            return;
        }

        sH.StartMoveAnimation(SpriteHandler.AnimationType.attack);
        magicCharge = 0f;
        float cooldown = equippedWeapon.Throw(gameObject, direction);
        StartCoroutine(EnableCanThrowIn(cooldown));
    }
}
