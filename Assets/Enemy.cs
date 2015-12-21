using UnityEngine;
using System.Collections;

public class Enemy : Actor {


    public enum EnemyMode { 
    
        wander,aggro
    }

    public EnemyMode currentMode = EnemyMode.wander;
    public Vector3 TargetPosition;
    float wanderRange = 10f;
    float wanderFrequencyChange = 3f;
    float currentWanderFrequencyTimer = 0f;

    float attackFreq = 2f;
    float currentAttackTimer;
    GameObject Player;

	// Use this for initialization
	void Start () {
        base.Start();
        Player = GameObject.FindGameObjectWithTag("Friendly");
        TargetPosition = transform.position;
	}

    void JumpAttack() {


        Jump();
        Vector3 direction = Player.transform.position - transform.position;
        Push(direction.normalized, 10, 1);

        
        
    
    }

    void Attack() {

        JumpAttack();
    
    }
	
	// Update is called once per frame
	void Update () {


        if (currentMode == EnemyMode.aggro)
        {
            //Debug.Log(TargetPosition.ToString()+" "+transform.position.ToString()+" "+(TargetPosition - transform.position).magnitude);

            TargetPosition = Player.transform.position;
            Move(Vector3.Scale((TargetPosition - transform.position), new Vector3(1, 0, 1)));
            

            if ((TargetPosition - Player.transform.position).sqrMagnitude < 200) {


                currentAttackTimer -= Time.deltaTime;
                if (currentAttackTimer < 0)
                {
                    currentAttackTimer = attackFreq;
                    Attack();
                }

                
            }
            

        }

       

        if (currentMode == EnemyMode.wander)
        {
            //Debug.Log(TargetPosition.ToString()+" "+transform.position.ToString()+" "+(TargetPosition - transform.position).magnitude);
            currentWanderFrequencyTimer -= Time.deltaTime;
            if (currentWanderFrequencyTimer < 0)
            {
                currentWanderFrequencyTimer = wanderFrequencyChange+Random.Range(0,1f);
                TargetPosition = transform.position+ new Vector3(Random.Range(-wanderRange, wanderRange), 0f, Random.Range(-wanderRange, wanderRange));            
            }
                         
            Move(Vector3.Scale((TargetPosition - transform.position), new Vector3(1, 0, 1)));

            

            if ((Player.transform.position - transform.position).sqrMagnitude < 300.0f)
            {
                currentMode = EnemyMode.aggro;
            }
        
        }


        
	
	}

    public override void TakeDamage(int dmg, Vector3 direction) {
        base.TakeDamage(dmg, direction);
        Debug.Log("rat jumps");
        if(rB.velocity.y==0f)
            rB.velocity += new Vector3(0, 10f, 0);


        Debug.Log(rB.velocity);
    
    }

    
}
