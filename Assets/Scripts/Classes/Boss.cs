using UnityEngine;
using System.Collections;

public class Boss : EnemySpellcaster {


    public void Start() {
        base.Start();
        loot = (GameObject)Resources.Load("Prefabs/Features/Chest");
        GeneralUI.Instance.ShowMessage("Prepare to fight!");
    }

	
}
