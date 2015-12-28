using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {


    public float speed;
    public float ttl;
    public Vector3 direction;
    public string tag;
    public GameObject ParticleHit;

    public float gravity;
    public float dropPercent;

    bool goDown;

    float currentTTL;

    public GameObject particleOnHitWall;
	// Use this for initialization

    public SpriteHandler sH;

    void Awake() {
        
        sH = GetComponentInChildren<SpriteHandler>();
    }

    void OnEnable() {

        ttl += Random.Range(0f, ttl * 0.1f);        
        currentTTL = ttl;
        
    }

   
	
	// Update is called once per frame
	void Update () {

        transform.Translate(direction * speed*Time.deltaTime);

        currentTTL-=Time.deltaTime;
        if (currentTTL < -ttl*2)
        {
            Kill();
        }

        if (goDown)
        {
            transform.Translate(Vector3.up * gravity * Time.deltaTime);
            gravity *= 1.1f;
        }

        else { 
            if(currentTTL < dropPercent*ttl){
                goDown = true;
            }
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

        if (go.tag == "Floor") {
            Instantiate(particleOnHitWall,transform.position,Quaternion.identity);
            AudioManager.PlayClip(AudioClipsType.thump);
            Kill();
        }

        Debug.Log(go.tag);
            
    }

    void Kill()
    {
        Destroy(this.gameObject);
    }
}
