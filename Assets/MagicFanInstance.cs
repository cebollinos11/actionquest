using UnityEngine;
using System.Collections;

public class MagicFanInstance : MonoBehaviour {

    public GameObject projectile;

    public int numberOfProjectiles;
    public float waitTime;

    public Vector3 direction;
    public GameObject owner;

    IEnumerator CastFan()
    {

        for (int i = 0; i < numberOfProjectiles; i++)
        {
            ThrowOneProjectile(Quaternion.Euler(0,i*10-(numberOfProjectiles-i)/2*10,0)*direction);
            yield return new WaitForSeconds(waitTime);
        }

        Destroy(gameObject);

    }

    public void Run(GameObject owner1, Vector3 direction1)
    {
        owner = owner1;
        direction = direction1;
        transform.parent = owner.transform;
        StartCoroutine(CastFan());
    }

    void ThrowOneProjectile(Vector3 direction1)
    {

        GameObject go = (GameObject)Instantiate(projectile, owner.transform.position + Vector3.up, owner.transform.rotation);
        Projectile pj = go.GetComponent<Projectile>();
        pj.direction = direction1;
        pj.tag = owner.gameObject.tag;

    }
}
