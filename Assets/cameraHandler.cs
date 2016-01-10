using UnityEngine;
using System.Collections;

public class cameraHandler : MonoBehaviour {

    Camera cam;
    float originalSize;
    [SerializeField]
    float shakeStrength;
    [SerializeField]
    float shakeDuration;
    
    float shakeFrequency;
    public float zoomTime;

    private float yVelocity = 0.0F;
	// Use this for initialization
	void Start () {
        cam = GetComponent<Camera>();
        originalSize = cam.fieldOfView;
        shakeFrequency = 1 / shakeDuration;
        ZoomOut();
	}

    



    public void ZoomOut() {
        StartCoroutine(FocusToOutside());
    }

    public void ZoomIn()
    {
        StartCoroutine(FocusToInside());
    }

    public void ShakeCam() {
        StartCoroutine(ShakeIT());
    }

    public void FadeOut()
    { 
    
    }

    IEnumerator ShakeIT() {

        float currentShake = shakeDuration;
        Vector3 originalPos = transform.position;

        float currentStrength = shakeStrength;

        

        do
        {
            float y = Mathf.Sin(2 * Mathf.PI * shakeFrequency * (shakeDuration - currentShake)) * currentStrength;            
            transform.position += new Vector3(0, -y, 0);   
            //cam.orthographicSize -= y;
            currentShake -= Time.deltaTime;
            yield return new WaitForEndOfFrame();

        } while (currentShake > 0);

        //transform.position = originalPos;
        cam.orthographicSize = originalSize;

        

    }


    IEnumerator FocusToOutside() {

        

        
        do
        {
            float newPosition = Mathf.SmoothDamp(cam.fieldOfView, originalSize, ref yVelocity, zoomTime);
            cam.fieldOfView = newPosition;
            yield return new WaitForEndOfFrame();
        }

        while (cam.orthographicSize - originalSize < 0.1f);
        
    }


    IEnumerator FocusToInside()
    {

       
        float targetSize = 5f;
        yVelocity = 0.0F;
        //cam.orthographicSize = 2;
        do
        {
            
            float newPosition = Mathf.SmoothDamp(cam.fieldOfView, targetSize, ref yVelocity, zoomTime);
            newPosition = Mathf.Lerp(cam.fieldOfView,targetSize,0.5f);
            cam.fieldOfView = newPosition;

            yield return new WaitForEndOfFrame();
        }

        while (cam.fieldOfView - targetSize > 0.1f);

        //Debug.Log(cam.orthographicSize - targetSize);

    }

}
