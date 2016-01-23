using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour {

    public Text MainText;
    public Text ExitText;
    public Text SecondaryText;
    public Image MainImage;
    public Button ContinueButton;

	// Use this for initialization
	void Start () {

        ExitText.enabled = false;
        ContinueButton.gameObject.SetActive(false);
	}

    public IEnumerator DelayShowContinue() {

        yield return new WaitForSeconds(1f);
        ContinueButton.gameObject.SetActive(true);
    
    }

    public void SetMainImage(Sprite sprite) {

        MainImage.sprite = sprite;
    
    }

    public void SetMainText(string text) {
        MainText.text = text;
    }

    public void SetSecondaryText(string text)
    {
        SecondaryText.text = text;
    }



}
