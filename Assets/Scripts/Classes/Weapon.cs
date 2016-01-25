using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

    public string name;
    public GameObject projectile;
    public Sprite sprite;
    

    public float damageBonus;

    public float Throw(GameObject owner,Vector3 direction)
    {
        //         GameObject go = (GameObject)Instantiate(toInstantiate, owner1.transform.position -Vector3.up*owner1.transform.localScale.y + Vector3.up, owner1.transform.rotation);

        GameObject go = (GameObject)Instantiate(projectile, owner.transform.position - Vector3.up * owner.transform.localScale.y + Vector3.up, Quaternion.identity);
        Projectile pj = go.GetComponent<Projectile>();
        AudioManager.PlaySpecific(pj.soundOnThrow);

        pj.InitProjectile(direction, owner.tag);
        pj.damage += damageBonus;
        return pj.cooldown;
    
    }    

}
