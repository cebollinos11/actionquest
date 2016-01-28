﻿using UnityEngine;
using System.Collections;

public class Spell : MonoBehaviour {

    
    public GameObject toInstantiate;
    public AudioClip soundOnCast;

    GameObject particlesOnCast;


    public virtual void Cast(GameObject owner,Vector3 direction) {

        AudioManager.PlaySpecific(soundOnCast);        
    
    }
}
