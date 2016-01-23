using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BattleUI : MonoBehaviour {

    PlayerController pc;
    [SerializeField]Text playerHP;
    [SerializeField]
    Text coins;
    [SerializeField]
    Image equippedWeap;

    [SerializeField]
    Text damageBonusWeapon;

	// Use this for initialization
	void Start () {
        pc = LevelManager.Instance.Player.GetComponent<PlayerController>();
	}

    public void UpdatePlayer() {

        playerHP.text = pc.currHP.ToString() + "/"+pc.maxHP.ToString();

        
        equippedWeap.sprite = pc.equippedWeapon.sprite;
        coins.text = pc.coins.ToString();

        damageBonusWeapon.text = pc.equippedWeapon.damageBonus.ToString();
    
    }
	
	
}
