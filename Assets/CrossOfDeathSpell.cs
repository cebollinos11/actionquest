using UnityEngine;
using System.Collections;

public class CrossOfDeathSpell : Spell {

    //public GameObject projectile;

    

    public override void Cast(GameObject owner, Vector3 direction)
    {

        GameObject projectile;

        projectile = owner.GetComponent<PlayerController>().equippedWeapon.GetComponent<Weapon>().projectile;

        for (int i = 0; i < 8; i++)
        {
            GameObject pj = (GameObject)Instantiate(projectile, owner.transform.position - Vector3.up * owner.transform.localScale.y + Vector3.up, Quaternion.identity);
            Projectile pjp = pj.GetComponent<Projectile>();
            pjp.InitProjectile(Quaternion.Euler(0, i*45, 0) * Vector3.forward, owner.tag);
            pjp.range *= 1.5f;
        }
        
        base.Cast(owner, direction);
        
    }
}
