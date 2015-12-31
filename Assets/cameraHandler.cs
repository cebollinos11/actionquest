using UnityEngine;
using System.Collections;

public class cameraHandler : MonoBehaviour {

    Camera cam;
    float originalSize;
    [SerializeField]
    float shakeStrength;
    [SerializeField]
    float shakeDuration;
    public float zoomTime;

    private float yVelocity = 0.0F;
	// Use this for initialization
	void Start () {
        cam = GetComponent<Camera>();
        originalSize = cam.orthographicSize;
	}

    void Update() {

        
            
    }

    public void ShakeCam() {
        StartCoroutine(ShakeIT());
    }


    IEnumerator ShakeIT() {

        float currentShake = shakeDuration;
        Vector3 originalPos = transform.position;
        

        do
        {

            transform.position += Random.insideUnitSphere * shakeStrength;            
            currentShake -= Time.deltaTime;
            yield return new WaitForEndOfFrame();

        } while (currentShake > 0);

        transform.position = originalPos;

    }


    IEnumerator FocusToOutside() {

        

        cam.orthographicSize = 2;
        do
        {
            float newPosition = Mathf.SmoothDamp(cam.orthographicSize, originalSize, ref yVelocity, zoomTime);
            cam.orthographicSize = newPosition;
            yield return new WaitForEndOfFrame();
        }

        while (cam.orthographicSize - originalSize < 0.1f);
        
    }


}
