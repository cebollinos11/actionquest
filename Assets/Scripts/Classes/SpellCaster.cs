using UnityEngine;
using System.Collections;

public class SpellCaster : Actor {

    public GameObject basicSpell;
    public GameObject specialSpell;
    protected Spell loadedBasicSpell;
    protected Spell loadedSpecialSpell;

    protected float magicCharge;
    protected float magicChargeLimit = 1f;

    protected bool canCastSpecial;

    AudioClip magicReadyClip;


    void checkCanCast() {



        if (magicCharge > magicChargeLimit)
        {
            if (!canCastSpecial) {
                sH.Flash(Color.cyan,1);
                AudioManager.PlaySpecific(magicReadyClip);
            }
            canCastSpecial = true;
        }

        else {

            canCastSpecial = false;
        }
            


    }

    public void Start()
    {
        base.Start();
        loadedBasicSpell = basicSpell.GetComponent<Spell>();
        loadedSpecialSpell = specialSpell.GetComponent<Spell>();
        magicReadyClip = (AudioClip)Resources.Load("Audio/SFX/magicReady");
  


    }

    public void  ChargeMagic(float time){

        magicCharge += time;
        checkCanCast() ;
    
    }

    public void CastSpell(Spell spellToCast, Vector3 direction)
    {
        sH.StartMoveAnimation(SpriteHandler.AnimationType.attack);
        sH.Flash(Color.white, 1);
        magicCharge = 0f;
        checkCanCast();
        spellToCast.Cast(this.gameObject, direction);
    }

    
}
