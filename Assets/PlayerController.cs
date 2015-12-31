using UnityEngine;
using System.Collections;

public class PlayerController : SpellCaster
{

    
    float _h, _v;
    public Vector3 lastDirection;

    SpellAimer spellAimer;

    

    void Start() {
        base.Start();
        spellAimer = GetComponentInChildren<SpellAimer>();
        lastDirection = Vector3.right;
    
    }
	
	// Update is called once per frame
	void Update () {        

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
            CastSpell(loadedBasicSpell, Vector3.forward);            
        }

        if (Input.GetButtonDown("AttackS"))
        {
            CastSpell(loadedBasicSpell, Vector3.back);
        }

        if (Input.GetButtonDown("AttackW"))
        {
            CastSpell(loadedBasicSpell, Vector3.left);
        }

        if (Input.GetButtonDown("AttackE"))
        {
            CastSpell(loadedBasicSpell, Vector3.right);         
        }

        if (Input.GetButtonDown("Jump"))
        {
            //Jump();

            Push(new Vector3(h, 0f, v),15,0.4f);
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

    public override void TakeDamage(int dmg, Vector3 dir)
    {
        base.TakeDamage(dmg, dir);
        ActionController.CamShake();
    }

    
}
