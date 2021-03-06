﻿using UnityEngine;
using System.Collections;

public class PlayerController : PlayerActor
{

    
    float _h, _v;
    public Vector3 lastDirection;
    

    SpellAimer spellAimer;

    

    [HideInInspector]public int coins;
    

    void Start() {
        base.Start();
        Debug.Log("player controller init");
        spellAimer = GetComponentInChildren<SpellAimer>();
        lastDirection = Vector3.right;
        
        
    
    }
	
	// Update is called once per frame
	void Update () {


        if (Input.GetKeyDown(KeyCode.Q))
        {
            TakeDamage(0, Vector3.zero);
        }

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (h != 0f || v!=0f) {

            lastDirection = new Vector3(h, 0f, v);
            Move(lastDirection);
            _h = h;
            _v = v;
            lastDirection.Normalize();
        }

        if (Input.GetButtonDown("AttackN"))
        {
            Throw(Vector3.forward);            
        }

        if (Input.GetButtonDown("AttackS"))
        {
            Throw(Vector3.back);
        }

        if (Input.GetButtonDown("AttackW"))
        {
            Throw(Vector3.left);
        }

        if (Input.GetButtonDown("AttackE"))
        {
            Throw(Vector3.right);         
        }

        if (Input.GetButtonDown("Jump"))
        {
            
            //Jump();
            Push(new Vector3(h, 0f, v),15,0.4f);
            sH.Mask(Color.blue);
            sH.StartMoveAnimation(SpriteHandler.AnimationType.dash);
            AudioManager.PlayClip(AudioClipsType.dash);
        }

        
        //charge magic
        if (Input.GetButton("AttackW") || Input.GetButton("AttackN") ||Input.GetButton("AttackE") ||Input.GetButton("AttackS"))
        {
             ChargeMagic(Time.deltaTime);
        }


        if (canCastSpecial)
        {

            //spellAimer
            spellAimer.turnOn(true);

            if (Input.GetButtonUp("AttackN"))
            {
                CastSpell(loadedSpecialSpell, lastDirection);
            }

            if (Input.GetButtonUp("AttackS"))
            {
                CastSpell(loadedSpecialSpell, lastDirection);
            }

            if (Input.GetButtonUp("AttackW"))
            {
                CastSpell(loadedSpecialSpell, lastDirection);
            }

            if (Input.GetButtonUp("AttackE"))
            {
                CastSpell(loadedSpecialSpell, lastDirection);
            }

        }

        else {
            spellAimer.turnOn(false);
            
        }


      

        


        

	
	}

    public override void TakeDamage(float dmg, Vector3 dir)
    {
        base.TakeDamage(dmg, dir);
        ActionController.CamShake();
        LevelManager.Instance.bui.UpdatePlayer();
    }



    

    
}
