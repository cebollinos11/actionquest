using UnityEngine;
using System.Collections;

public class Enemy : Actor {

    public bool instantPrefab;


    public enum EnemyMode {     
        wander,aggro
    }

    public AudioClip warCrySound;
    public bool noMelee;
    public float meleeDash = 10f;
    [HideInInspector]public EnemyMode currentMode = EnemyMode.wander;
    [HideInInspector]public Vector3 TargetPosition;
    float wanderRange = 10f;
    float wanderFrequencyChange = 3f;
    float currentWanderFrequencyTimer = 0f;

    public float attackFreq = 2f;
    float currentAttackTimer;
    [HideInInspector] public GameObject Player;

    

    protected Vector3 currentPositionDifferenceToTarget;

    protected GameObject loot;

    public GameObject startingWeapon;
    Weapon weaponScript;


    

	// Use this for initialization
	public void Start () {
        base.Start();
        
        Player = GameObject.FindGameObjectWithTag("Friendly");
        TargetPosition = transform.position;
        loot = LevelManager.ReturnLoot();   
    
        //randomly make it big
        if (Random.Range(0, 100) > 95)
        {
            transform.localScale *= 2;        
        }

        if (startingWeapon)
        {
            weaponScript = startingWeapon.GetComponent<Weapon>();
        }

	}


    IEnumerator JumpAttackTimed() {

        //audio     
        float jumpAtackFreezeTime = 0.2f + Random.Range(0f,0.5f);
        //sH.Flash(Color.black, 1);
        sH.Mask(Color.red);
        BlockMove(jumpAtackFreezeTime);
        yield return new WaitForSeconds(jumpAtackFreezeTime);

        maxSpeed *= 2;

        yield return new WaitForSeconds(0.3f);

        maxSpeed /= 2;


        JumpAttack();
    


    }

    void JumpAttack() {

        AudioManager.PlaySpecific(warCrySound);
        Jump();
        Vector3 direction = Player.transform.position - transform.position;
        Push(direction.normalized, meleeDash, 1);       
    
    }

    void Attack(float distToTarget) {

        
            

        if (weaponScript )
        {
            if(Random.Range(1,100)>50)
                AudioManager.PlaySpecific(warCrySound);

            sH.Mask(Color.grey);
            weaponScript.Throw(gameObject, Vector3.Scale( (Player.transform.position - transform.position).normalized , new Vector3(1,0,1)));
        }

        else {

            if (distToTarget > 150)
                return;

            StartCoroutine(JumpAttackTimed());        
        }



        currentAttackTimer = attackFreq + Random.Range(0f, attackFreq * 0.3f);
        
    
    }
	
	// Update is called once per frame
	public void Update () {

        currentPositionDifferenceToTarget = Player.transform.position - transform.position;


        

        if (currentMode == EnemyMode.aggro)
        {
            //Debug.Log(TargetPosition.ToString()+" "+transform.position.ToString()+" "+(TargetPosition - transform.position).magnitude);

            TargetPosition = Player.transform.position;

            
            Move(Vector3.Scale(currentPositionDifferenceToTarget, new Vector3(1, 0, 1)));


            if (!noMelee && (currentPositionDifferenceToTarget).sqrMagnitude < 300)
            {


                currentAttackTimer -= Time.deltaTime;
                if (currentAttackTimer < 0)
                {

                    Attack((currentPositionDifferenceToTarget).sqrMagnitude);
                    
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

    public override void TakeDamage(float dmg, Vector3 direction) {
        base.TakeDamage(dmg, direction);
        
        if(rB.velocity.y==0f)
            rB.velocity += new Vector3(0, 10f, 0);

        currentAttackTimer = attackFreq + Random.Range(0f, attackFreq * 0.3f);


        currentMode = EnemyMode.aggro;
    
    }

    public override void Die() {

        base.Die();
        AudioManager.PlayClip(AudioClipsType.enemyDead);
        Instantiate(loot, transform.position, Quaternion.identity);
        LevelManager.Instance.currentRoom.CheckForEnemiesAlive();
        
    }

    
}
