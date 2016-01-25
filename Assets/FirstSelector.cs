using UnityEngine;
using System.Collections;

public class FirstSelector : MonoBehaviour {

    void OnEnable() {

        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(this.gameObject);
        Debug.Log("Button awake");
    
    }
}
