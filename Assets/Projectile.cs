using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {


    public float speed;
    public float ttl;
    public Vector3 direction;
    public string tag;
    public GameObject ParticleHit;

    float currentTTL;
	// Use this for initialization

    public SpriteHandler sH;

    void Awake() {
        
        sH = GetComponentInChildren<SpriteHandler>();
    }

    void OnEnable() {
        
        currentTTL = ttl;
        
    }
	
	// Update is called once per frame
	void Update () {

        transform.Translate(direction * speed*Time.deltaTime);

        currentTTL-=Time.deltaTime;
        if (currentTTL < 0)
        {
            Kill();
        }
	    
	}

    void OnTriggerEnter(Collider col)
    {
        
        
        
        GameObject go = col.gameObject;
        if(tag!=go.tag)
        {
            go.GetComponent<Actor>().TakeDamage(1, direction);
            Instantiate(ParticleHit, transform.position, Quaternion.identity);
            Kill();
        }
            
    }

    void Kill()
    {
        Destroy(this.gameObject);
    }
}
