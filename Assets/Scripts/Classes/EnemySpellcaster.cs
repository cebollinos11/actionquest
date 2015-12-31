using UnityEngine;
using System.Collections;

public class EnemySpellcaster : Enemy {

    public GameObject knownSpell;
    public float spellFrequency = 4f;
    float currentSpellFreq;

	// Use this for initialization
	void Start () {
        base.Start();
	
	}
	
	// Update is called once per frame
	void Update () {
        base.Update();

        if (currentMode == EnemyMode.aggro)
        {


            HandleSpells();

        }

        
	
	}

    void HandleSpells() {

        if (currentSpellFreq < 0)
        {
            currentSpellFreq = spellFrequency;
            if (currentPositionDifferenceToTarget.magnitude < 200)
            {
                CastSpell();
            }
        }
        else
        {
            currentSpellFreq -= Time.deltaTime;
        }
    }

    void CastSpell() {

        knownSpell.GetComponent<Spell>().Cast(this.gameObject,Vector3.Scale((Player.transform.position-transform.position),new Vector3(1,0,1)).normalized);
    
    }
}
