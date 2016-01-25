using UnityEngine;
using System.Collections;

public class WeaponFoundEvent : DoubleOptionEvent {

    Weapon newWeaponScript;

    void Awake() {


            Debug.Log("awake executed");
            GameObject newWeapon =  LevelManager.Instance.WeaponDB[Random.Range(0, LevelManager.Instance.WeaponDB.Count)];
            newWeaponScript = newWeapon.GetComponent<Weapon>();
            MainSprite = newWeaponScript.sprite;
            
            //

            mainText = "You find a " + newWeaponScript.name;
            secondaryText = "Do you take it?";

    
    }

    public override void OnClick1()
    {
        mainText = "";
        secondaryText = "You take it! Ready to kick ass";
        LevelManager.Instance.Player.GetComponent<PlayerActor>().equippedWeapon = newWeaponScript;
        base.OnClick1();

    }

    public override void OnClick2()
    {
        mainText = "";
        secondaryText = "You think you could do more damage with a chicken drumstick...";
        base.OnClick2();
    }
	
}
