using UnityEngine;
using System.Collections;

public class SpriteHandler : MonoBehaviour {

    [SerializeField]
    float MoveTime = 0.1f;
    [SerializeField]
    float MoveAnimIntensity=0.2f;
    bool isMoving;
    [SerializeField]
    float flashTime = 0.5f;

    Color baseColor;
    Vector3 baseScale;
    [HideInInspector]
    public SpriteRenderer sR;

    public int spriteOrientation = 1;    

    public enum AnimationType { 
        walk,jump,attack
    }

    public void SetSpriteOrientation(int orientation)
    {

        spriteOrientation = orientation;

        if (baseScale.x * spriteOrientation < 0)
            baseScale = new Vector3(-baseScale.x, baseScale.y, baseScale.z);

        if (transform.localScale.x * spriteOrientation < 0)
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
    void Awake() {
       
        sR = GetComponent<SpriteRenderer>();
        baseColor = sR.color;
        baseScale = transform.localScale;
        
    }

    void Update() {

        if (Input.GetKeyDown(KeyCode.C)) {

            RunDie();

        }

        if(transform.localScale.x*spriteOrientation < 0)
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        
    }

    public void Mask(Color color)
    {

        StartCoroutine(MaskIT(color));
    }

    IEnumerator MaskIT(Color color) {

        float val = 1f;
        sR.material.SetColor("_MaskColor", color);
        sR.material.SetFloat("_MaskAmount", val);

        do {
            val -= 0.1f;
            sR.material.SetFloat("_MaskAmount", val);
            yield return new WaitForSeconds(0.02f);
        
        }
        while (val > 0);
    
    }

    public void Flash(Color targetColor, int times) {
        StartCoroutine(FlashIt(targetColor, times));
    }

    IEnumerator FlashIt(Color targetColor, int times)
    {

        do
        {

            float currentTime = flashTime;
            do
            {
                
                sR.color = Color.Lerp(baseColor, targetColor, currentTime / flashTime);
                currentTime -= Time.deltaTime;
                yield return null;

            } while (currentTime > 0f);

            //safe zone
            sR.color = baseColor;
            times--;
        } while (times > 0);
        

    }


    public void StartMoveAnimation(AnimationType aType) {

        

        if (isMoving && aType == AnimationType.walk) {
            return;
        }

        isMoving = true;
        StartCoroutine(RunWalkAnim(aType));
    }

    IEnumerator RunWalkAnim(AnimationType aType) {

        float currentTime = MoveTime;

        Vector3 secureOrigScale = baseScale;
        Vector3 origScale = baseScale;
        Vector3 targetScale = Vector3.zero;

        if(aType == AnimationType.walk)
            targetScale = new Vector3(origScale.x * (1f + MoveAnimIntensity) , origScale.y * (1f - MoveAnimIntensity), origScale.z);
        else if(aType == AnimationType.jump)
            targetScale = new Vector3(origScale.x * (1f - MoveAnimIntensity) , origScale.y * (1f + MoveAnimIntensity * 2), origScale.z);

        else if (aType == AnimationType.attack)
            targetScale = new Vector3(origScale.x * (1f + MoveAnimIntensity * 2) , origScale.y*0.9f, origScale.z);           

        do {

            if (targetScale.x * spriteOrientation < 0)
            {
                targetScale = new Vector3(-targetScale.x, targetScale.y, targetScale.z);
                origScale = new Vector3(-origScale.x, origScale.y, origScale.z);
            }
            

            transform.localScale = Vector3.Lerp(targetScale,origScale, currentTime / MoveTime);
            
            currentTime -= Time.deltaTime;
            yield return null;

        } while (currentTime > 0f);

        currentTime = MoveTime;
        targetScale = origScale;
        origScale = transform.localScale;

        do
        {
            if (targetScale.x * spriteOrientation < 0)
            {
                targetScale = new Vector3(-targetScale.x, targetScale.y, targetScale.z);
                origScale = new Vector3(-origScale.x, origScale.y, origScale.z);
            }
                
            transform.localScale = Vector3.Lerp(targetScale, origScale, currentTime / MoveTime);
            
            currentTime -= Time.deltaTime;
            yield return null;

        } while (currentTime > 0f);



        transform.localScale = secureOrigScale;


        currentTime = MoveTime*2;
        do
        {
            
            currentTime -= Time.deltaTime;
            yield return null;

        } while (currentTime > 0f);


        
        isMoving = false;
    
    }

    public void RunDie() {
        sR.material.SetFloat("_MaskAmount", 0.5f);
        StopAllCoroutines();
        StartCoroutine(Die());
    }
    IEnumerator Die()
    {
        float currentTime = MoveTime;

        Vector3 secureOrigScale = transform.localScale;

        Vector3 origScale = transform.localScale;
        Vector3 targetScale = new Vector3(origScale.x * (1.2f), origScale.y * (0.1f), origScale.z);

        do
        {
           
            transform.localScale = Vector3.Lerp(targetScale, origScale, currentTime / MoveTime);
            currentTime -= Time.deltaTime*0.1f;
            yield return new WaitForEndOfFrame();

        } while (currentTime > 0f);

        transform.localScale = targetScale;
        sR.color = Color.Lerp(sR.color, new Color(0.5f, 0.5f, 0.5f, 0.1f),0.5f);
       
        
    }

    

}
