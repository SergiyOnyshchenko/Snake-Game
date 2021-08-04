using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : Food
{
    private void Start() 
    {
        Edible = new AlwaysEdible();
    }

    protected override void FinishEat()
    {
        FoodManager.Instance.AddGem();
    }
}
