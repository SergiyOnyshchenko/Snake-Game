using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorFoodCountView : CountView
{
    private void Start()
    {
        FoodManager.Instance.ColorFoodAded += SetCount;
    }

    private void OnDestroy()
    {
        FoodManager.Instance.ColorFoodAded -= SetCount;
    }
}
