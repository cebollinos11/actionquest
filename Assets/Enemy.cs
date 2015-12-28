using UnityEngine;
using System.Collections;

public class Enemy : Actor {


    public enum EnemyMode { 
    
        wander,aggro
    }

    public float meleeDash = 10f;
    public EnemyMode currentMode = EnemyMode.wander;
    public Vector3 TargetPosition;
    float wanderRange = 10f;
    float wanderFrequencyChange = 3f;
    float currentWanderFrequencyTimer = 0f;

    public float attackFreq = 2f;
    float currentAttackTimer;
    GameObject Player;

    public AudioClip soundAttack;

    GameObject loot;

	// Use this for initialization
	void Start () {
        base.Start();
        Player = GameObject.FindGameObjectWithTag("Friendly");
        TargetPosition = transform.position;
        loot = (GameObject)Resources.Load("Prefabs/Loot/Money");
	}


    IEnumerator JumpAttackTimed() {

        //audio

        


        sH.Flash(Color.magenta, 2);
        BlockMove(0.5f);
        yield return new WaitForSeconds(0.5f);


        JumpAttack();
    


    }

    void JumpAttack() {

        AudioManager.PlayClip(AudioClipsType.dash);
        Jump();
        Vector3 direction = Player.transform.position - transform.position;
        Push(direction.normalized, meleeDash, 1);

        

        
        
    
    }

    void Attack() {

        StartCoroutine(JumpAttackTimed());
        
    
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
                    currentAttackTimer = attackFreq+Random.Range(0f,attackFreq*0.3f);
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

    public override void Die() {

        base.Die();
        AudioManager.PlayClip(AudioClipsType.enemyDead);
        Instantiate(loot, transform.position, Quaternion.identity);
    }

    
}
