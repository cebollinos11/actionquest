using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour {

    public Text MainText;
    public Text ExitText;
    public Image MainImage;

	// Use this for initialization
	void Start () {

        ExitText.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetMainImage(Sprite sprite) {

        MainImage.sprite = sprite;
    
    }
}
