using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFood : Food
{
    private void Start()
    {
        Edible = new AlwaysEdible();
    }

    protected override void FinishEat()
    {
        FoodManager.Instance.AddColorFood();
    }
}
