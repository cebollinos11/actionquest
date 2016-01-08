using UnityEngine;
using System.Collections;

public class GoldCoins : MonoBehaviour {

    public AudioClip moneySound;
    GameObject particlePickUp;

    void Start() {
        pushUp();
        particlePickUp = (GameObject)Resources.Load("Prefabs/Particles/ParticlesPickUp");
    }

    void pushUp() {
        GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-10.0F, 10.0F), 30f, Random.Range(-10.0F, 10.0F));    
    }

   

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "Friendly")
        {
            AudioManager.PlaySpecific(moneySound);
            Instantiate(particlePickUp, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            col.gameObject.GetComponent<PlayerController>().coins++;
            LevelManager.Instance.bui.UpdatePlayer();
        }
    }
}
