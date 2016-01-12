using UnityEngine;
using System.Collections;

public class PlayerActor : SpellCaster
{

    public GameObject EquippedWeapon;
    [HideInInspector]public Projectile equippedProjectile;

    bool canThrow = true;

    public void Start() {

        Debug.Log("player actor init");
        base.Start();
        equippedProjectile = EquippedWeapon.GetComponent<Projectile>();
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
        GameObject go = (GameObject)Instantiate(EquippedWeapon, transform.position + Vector3.up, Quaternion.identity);
        Projectile pj = go.GetComponent<Projectile>();
        pj.InitProjectile(direction, gameObject.tag);
        AudioManager.PlaySpecific(equippedProjectile.soundOnThrow);
        StartCoroutine(EnableCanThrowIn(pj.cooldown));
    }
}
