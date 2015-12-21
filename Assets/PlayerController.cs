using UnityEngine;
using System.Collections;

public class PlayerController : Actor
{

    [SerializeField]
    GameObject MagicSpell;
    float _h, _v;
	
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
            CastMagicSpell(Vector3.forward);
        }

        if (Input.GetButtonDown("AttackS"))
        {
            CastMagicSpell(Vector3.back);
        }

        if (Input.GetButtonDown("AttackW"))
        {
            CastMagicSpell(Vector3.left);
        }

        if (Input.GetButtonDown("AttackE"))
        {
            CastMagicSpell(Vector3.right);
            CastMagicSpell(new Vector3(1,0,0.3f));
            CastMagicSpell(new Vector3(1, 0, -0.3f));
        }

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }


        


        

	
	}

    void CastMagicSpell(Vector3 direction) {
        sH.StartMoveAnimation(SpriteHandler.AnimationType.attack);
        sH.Flash(Color.blue, 1);

        GameObject go = (GameObject)Instantiate(MagicSpell, transform.position + direction + Vector3.up, transform.rotation);
        Projectile pj = go.GetComponent<Projectile>();
        pj.direction = direction;
        
        pj.tag = this.gameObject.tag;

        
        
    
    }
}
