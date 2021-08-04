using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysEdible : IEdible
{
    public bool CheckIsEdible(Eater eater)
    {
        return true;
    }
}
