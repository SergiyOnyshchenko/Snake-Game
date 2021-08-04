using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemCountView : CountView
{
    private void Start() 
    {
        FoodManager.Instance.GemAded += SetCount;
    }

    private void OnDestroy()
    {
        FoodManager.Instance.GemAded -= SetCount;
    }
}
