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

	// Use this for initialization
	void Start () {
        pc = LevelManager.Instance.Player.GetComponent<PlayerController>();
	}

    public void UpdatePlayer() {

        playerHP.text = pc.currHP.ToString();
        //equippedWeap.sprite = pc.EquippedWeapon.GetComponent<Projectile>().sH.gameObject.GetComponent<SpriteRenderer>().sprite;
        coins.text = pc.coins.ToString();
    
    }
	
	
}
