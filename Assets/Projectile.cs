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

    bool checkTags(string tag1,string tag2) { // return true if the two tags are opponents

        if (tag1 == "Friendly" && tag2 == "Enemy")
            return true;

        if (tag1 == "Enemy" && tag2 == "Friendly")
            return true;




        return false;
    
    }

    void OnTriggerEnter(Collider col)
    {       
        
        GameObject go = col.gameObject;
        if(checkTags(tag,go.tag))
        {
            Actor goActor = go.GetComponent<Actor>();
            goActor.TakeDamage(1, direction);
            goActor.BlockMove(0.2f);
            Instantiate(ParticleHit, transform.position, Quaternion.identity);
            Kill();
        }
            
    }

    void Kill()
    {
        Destroy(this.gameObject);
    }
}
