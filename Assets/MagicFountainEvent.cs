using UnityEngine;
using System.Collections;

public class MagicFountainEvent : DoubleOptionEvent {

    public override void OnClick1()
    {

        

        int die = Random.Range(0, 100);

        if (die < 50) {

            float n = Random.Range(1, pC.maxHP);

            secondaryText = "The holy water heals you!";
            pC.HealDamage(n);
            PlaySuccess();
            
        
        }

        else if (die < 75)
        {
            float dmg = Random.Range(0f, pC.maxHP / 2)+1;
            pC.TakeNonLethalDamage(dmg);

            secondaryText = "The water is poisoned! You lose " + ((int)dmg).ToString()+ " hit points!" ;
            PlayFail();
            
        }

        else if (die < 90)
        {
            secondaryText = "The magic water give you powers! Your max HP is increased!";
            pC.maxHP++;
            PlaySuccess();
        }

        else if (die < 101)
        {
            secondaryText = "The water is cursed! Your max HP is decreased!";
            pC.maxHP--;
            PlayFail();
        }


        base.OnClick1();
    }

    public override void OnClick2()
    {
        secondaryText = "Public water resources are never good";
        base.OnClick2();
    }
}
