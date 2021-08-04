using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public bool IsFinished {get; private set;}

    private void OnTriggerEnter(Collider other)
    {
        if(IsFinished)
            return;

        if (other.transform.parent == null)
            return;

        if(other.transform.parent.TryGetComponent(out Snake snake))
        {
            GameManager.Instance.FinishLevel();
            IsFinished = true;
        }
    }
}
