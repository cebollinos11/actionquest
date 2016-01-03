using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {


    public float speed;
    
    public float range;
    float distanceTravelled;
    [HideInInspector]public Vector3 direction;
    [HideInInspector]
    public string tag;

    float directionVariation = 0.1f;

    float currentTTL;
    float gravity = -10f;
    

    bool goDown;

   
    public GameObject particleOnHitWall;
	// Use this for initialization

    [HideInInspector]
    public SpriteHandler sH;

    void Awake() {
        
        sH = GetComponentInChildren<SpriteHandler>();
    }

    

    public void InitProjectile(Vector3 projectileDirection,string ownerTag) {

        direction = projectileDirection;
        tag = ownerTag;

        distanceTravelled = Random.Range(-0.5f, 0.5f);
        currentTTL = 0;
        direction += new Vector3(Random.Range(-directionVariation, directionVariation), 0, Random.Range(-directionVariation, directionVariation));
    
    }

   
	
	// Update is called once per frame
	void Update () {

        distanceTravelled += speed * Time.deltaTime;
        transform.Translate(direction * speed*Time.deltaTime);
        Debug.Log(direction);

        currentTTL-=Time.deltaTime;
        if (currentTTL < -15f)
        {
            Kill();
        }

        if (goDown)
        {
            transform.Translate(Vector3.up * gravity * Time.deltaTime);
            gravity *= 1.1f;
        }

        else { 
            //if(currentTTL < dropPercent*ttl){
            if(distanceTravelled>range){
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
            
            Kill();
        }

        if (go.tag == "Floor") {
            Instantiate(particleOnHitWall,transform.position+Vector3.up,Quaternion.identity);
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
