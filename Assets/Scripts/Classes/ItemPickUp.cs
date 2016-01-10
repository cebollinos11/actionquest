using UnityEngine;
using System.Collections;

public class ItemPickUp : MonoBehaviour {


    public AudioClip pickUpSound;
    public GameObject particlePickUp;
    float pickUpOffsetTime = 0.5f;
    bool canBePickedUp;

	// Use this for initialization
	void Start () {
        StartCoroutine(WaitForEnablePickUp());
        pushUp();       
	    
	}

    IEnumerator WaitForEnablePickUp()
    {

        yield return new WaitForSeconds(pickUpOffsetTime);
        canBePickedUp = true;
    }

    void pushUp()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-10.0F, 10.0F), 30f, Random.Range(-10.0F, 10.0F));
    }


    void OnCollisionEnter(Collision col)
    {
        if (canBePickedUp && col.gameObject.tag == "Friendly")
        {
            
            OnPickUp(col);
            LevelManager.Instance.bui.UpdatePlayer();
        }
    }

    public virtual void OnPickUp(Collision col)
    {
        AudioManager.PlaySpecific(pickUpSound);
        Instantiate(particlePickUp, transform.position, Quaternion.identity);

        
        Destroy(this.gameObject);
    }
}
