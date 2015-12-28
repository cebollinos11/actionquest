using UnityEngine;
using System.Collections;

public class PlayerController : SpellCaster
{

    
    float _h, _v;

    

    void Start() {
        base.Start();
        
    
    }
	
	// Update is called once per frame
	void Update () {        

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (h != 0f || v!=0f) {

            
            Move(new Vector3(h,0f,v));
            _h = h;
            _v = v;
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

            if (Input.GetButtonUp("AttackN"))
            {
                CastSpell(loadedSpecialSpell, Vector3.forward);
            }

            if (Input.GetButtonUp("AttackS"))
            {
                CastSpell(loadedSpecialSpell, Vector3.back);
            }

            if (Input.GetButtonUp("AttackW"))
            {
                CastSpell(loadedSpecialSpell, Vector3.left);
            }

            if (Input.GetButtonUp("AttackE"))
            {
                CastSpell(loadedSpecialSpell, Vector3.right);
            }
        
        }
        


        


        

	
	}

    
}
