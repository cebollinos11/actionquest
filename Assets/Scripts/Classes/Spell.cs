using UnityEngine;
using System.Collections;

public class Spell : MonoBehaviour {

    public string name;
    public GameObject toInstantiate;
    public AudioClip soundOnCast;


    public virtual void Cast(GameObject owner,Vector3 direction) {
        AudioManager.PlaySpecific(soundOnCast);
        Debug.Log(owner.name + " casts " + name);
    
    }
}
