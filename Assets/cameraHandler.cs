using UnityEngine;
using System.Collections;

public class cameraHandler : MonoBehaviour {

    Camera cam;
    float originalOffset;
    [SerializeField]
    float shakeStrength;
    [SerializeField]
    float shakeDuration;
    
    float shakeFrequency;
    public float zoomTime;

    float zoomInFov = 10f;

    private float yVelocity = 0.0F;
	// Use this for initialization
	void Start () {
        cam = GetComponent<Camera>();
        cam.fieldOfView = zoomInFov;
        shakeFrequency = 1 / shakeDuration;
        
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
        

        

    }


    IEnumerator FocusToOutside() {

        Debug.Log("STARTED CO");
        yield return new WaitForSeconds(1f);
        cam.fieldOfView = zoomInFov;
        float targetSize = 30f;
        yVelocity = 0.0F;
        //cam.orthographicSize = 2;
        do
        {

            float newPosition = Mathf.SmoothDamp(cam.fieldOfView, targetSize, ref yVelocity, zoomTime);
            //newPosition = Mathf.Lerp(cam.fieldOfView, targetSize, 0.5f);
            cam.fieldOfView = newPosition;
            Debug.Log("In the mix" + cam.fieldOfView + " vs"+ targetSize);

            yield return new WaitForEndOfFrame();
        }

        while (cam.fieldOfView - targetSize < -0.01f);
        Debug.Log("Finished CO");
    }


    IEnumerator FocusToInside()
    {


        float targetSize = zoomInFov;
        yVelocity = 0.0F;
        //cam.orthographicSize = 2;
        do
        {
            
            float newPosition = Mathf.SmoothDamp(cam.fieldOfView, targetSize, ref yVelocity, zoomTime);
            //newPosition = Mathf.Lerp(cam.fieldOfView,targetSize,0.5f);
            cam.fieldOfView = newPosition;

            yield return new WaitForEndOfFrame();
        }

        while (cam.fieldOfView - targetSize > 0.01f);

        //Debug.Log(cam.orthographicSize - targetSize);

    }

}
