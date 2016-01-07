using UnityEngine;
using System.Collections;

public class MaxSpeedDoubler : MonoBehaviour {

    Enemy enemyScript;
    bool isDoubled;
    public float period = 5f;
    public float percentage = 0.15f;

    public int multiplier = 4;

    [SerializeField]float count;
    bool alreadychanged;
    bool direction = true;
	// Use this for initialization
	void Start () {

        enemyScript = GetComponent<Enemy>();
        
	
	}
	
	// Update is called once per frame
	void Update () {

        count += Time.deltaTime;

        if (!alreadychanged && count > period * (1 - percentage))
        {
            alreadychanged = true;
            ChangeIt();

        }

        if (count > period) {
            ChangeIt();            
            count = 0f;
            alreadychanged = false;
        }

        
	    
	}

    void ChangeIt() {
        if (direction)
        {
            enemyScript.maxSpeed *= multiplier;
        }

        else {
            enemyScript.maxSpeed /= multiplier;
        }

        direction = !direction;
    
    }
}
