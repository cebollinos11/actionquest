using UnityEngine;
using System.Collections;

public class Actor : MonoBehaviour {

    public int speed = 100;
    public int maxSpeed = 10;
    public int jumpPower=10;

    public int isTouchingFloor;
    
    float WalkAnimLimit = 1f;

    public Rigidbody rB;

    public SpriteHandler sH;

    public void Start() {

        rB = GetComponent<Rigidbody>();
        sH = GetComponentInChildren<SpriteHandler>();

    }

    public void Move(Vector3 dir){
        

        rB.velocity += dir*speed*Time.timeScale*0.01f;

        //handle sprite orientation

        if (dir.x > 0.5)
        {
            sH.SetSpriteOrientation(-1);
            Debug.Log("orientation changed");
        }

        if (dir.x < -0.5)
        {
            sH.SetSpriteOrientation(1);
            
        }
        


        if (isTouchingFloor>0)
        {

            //sH.StartMoveAnimation(SpriteHandler.AnimationType.walk );

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

        Debug.Log("take damage in actor");
        sH.Flash(Color.red, 1);
        sH.StartMoveAnimation(SpriteHandler.AnimationType.walk);
        rB.velocity += dir * 10;
    }



    

 
}
