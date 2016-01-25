using UnityEngine;
using System.Collections;

public class MagicFountainEvent : DoubleOptionEvent {

    public override void OnClick1()
    {

        

        int die = Random.Range(0, 100);

        if (die < 50) {

            secondaryText = "The holy water heals you!";
            pC.HealDamage(5);
        
        }

        else if (die < 75)
        {
            secondaryText = "The magic water give you powers! Your max HP is increased!";
            pC.maxHP++;
        }

        else if (die < 101)
        {
            secondaryText = "The water is cursed! Your max HP is decreased!";
            pC.maxHP--;
        }


        base.OnClick1();
    }

    public override void OnClick2()
    {
        secondaryText = "Public water resources are never good";
        base.OnClick2();
    }
}
