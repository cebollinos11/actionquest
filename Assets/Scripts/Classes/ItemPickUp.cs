﻿using UnityEngine;
using System.Collections;

public class ItemPickUp : MonoBehaviour {


    public AudioClip pickUpSound;
    public GameObject particlePickUp;

	// Use this for initialization
	void Start () {
        pushUp();       
	
	}

    void pushUp()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-10.0F, 10.0F), 30f, Random.Range(-10.0F, 10.0F));
    }


    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Friendly")
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
