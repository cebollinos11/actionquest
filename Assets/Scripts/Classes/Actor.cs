using UnityEngine;
using System.Collections;

public class Actor : MonoBehaviour {

    public int maxHP = 5;
    int currHP;

    public int speed = 100;
    public int maxSpeed = 10;
    public int jumpPower=10;

    public int isTouchingFloor;
    
    float WalkAnimLimit = 1f;

    public Rigidbody rB;

    public SpriteHandler sH;

    int MoveBlocked;

    public AudioClip soundGetHit;

    

    public void BlockMove(float seconds){
        StartCoroutine(BlockMe(seconds));
    }

    IEnumerator BlockMe(float blocktime) {

        MoveBlocked++;
        
        yield return new WaitForSeconds(blocktime);
        
        MoveBlocked--;
    
    
    }

    public void Start() {

        currHP = maxHP;

        rB = GetComponent<Rigidbody>();
        sH = GetComponentInChildren<SpriteHandler>();

        gameObject.AddComponent<AudioSource>();
       

       

    }

    public void Push(Vector3 dir, float strength, float blockTime) {
        dir = dir * strength;
        rB.velocity += dir;
        BlockMove(blockTime);
    }

    public void Move(Vector3 dir){

        if (MoveBlocked > 0)
            return;

        rB.velocity += dir*speed*Time.timeScale*0.01f;

        //handle sprite orientation

        if (dir.x > 0.5)
        {
            sH.SetSpriteOrientation(-1);
            
        }

        if (dir.x < -0.5)
        {
            sH.SetSpriteOrientation(1);
            
        }



        if (isTouchingFloor > 0 && rB.velocity.y <= 0)
        {

            sH.StartMoveAnimation(SpriteHandler.AnimationType.walk );

            if (rB.velocity.magnitude > maxSpeed)
            {
                
                rB.velocity = rB.velocity.normalized * maxSpeed;
            }
        }

        else { //if its jumping

            float z = rB.velocity.y;

            rB.velocity = Vector3.Scale( rB.velocity , new Vector3(1, 0, 1));

            if (rB.velocity.magnitude > maxSpeed)
            {
                rB.velocity = rB.velocity.normalized * maxSpeed;
            }

            rB.velocity += new Vector3(0, z, 0);
        
        }  
            

        
        
    
    }

    public void Jump() {

        

        if (isTouchingFloor>0)
        {
            rB.velocity += new Vector3(0f, jumpPower, 0f);
            sH.StartMoveAnimation(SpriteHandler.AnimationType.jump);
            
        }
        
    
    }

    void OnCollisionEnter(Collision col)
    {
        //check floor
        if (col.gameObject.tag == "Floor") {
            sH.StartMoveAnimation(SpriteHandler.AnimationType.walk);
            isTouchingFloor ++;
        
        }


        if (col.gameObject.tag == "Friendly" && enabled)
        {
            
            Actor goActor = col.gameObject.GetComponent<Actor>();
            Vector3 dir = col.transform.position - transform.position;
            goActor.TakeDamage(1,dir);
            goActor.Push(dir,3,0.5f);
                
          
        }
    }


    void OnCollisionExit(Collision col)
    {
        //check floor
        if (col.gameObject.tag == "Floor")
        {

            isTouchingFloor--;

        }
    }


    public virtual void TakeDamage(int dmg, Vector3 dir)
    {

        //manage audio
        AudioManager.PlayClip(AudioClipsType.getHurt);


        Debug.Log("take damage in actor");
        sH.Flash(Color.red, 1);
        sH.StartMoveAnimation(SpriteHandler.AnimationType.walk);
        rB.velocity += dir * 10;

        currHP -= dmg;
        if (currHP < 1)
        {
            Die();
        }
        
    }

    public virtual void Die() {
        StopAllCoroutines();
        sH.RunDie();
        enabled = false;
        this.gameObject.tag = "Untagged";
        Invoke("RemoveRigidbody", 1f);
        
    }

    void RemoveRigidbody() {
        Vector3 scale = sH.transform.lossyScale;
        sH.transform.parent = null;
        sH.transform.localScale = scale;
        Destroy(this.gameObject);
    
    }



    

 
}
