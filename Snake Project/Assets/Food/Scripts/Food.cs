using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Food : MonoBehaviour
{
    [SerializeField] private float _eatTime = 5f;
    [SerializeField] private float _speed;
    
    public void Eat(Transform eater)
    {
        gameObject.layer = 2;

        Vector3 startScale = transform.localScale;
        Vector3 endScale = Vector3.zero;

        Sequence mySequence = DOTween.Sequence();
        mySequence = mySequence.Append(transform.DOScale(startScale * 1.1f, _eatTime / 2).SetEase(Ease.OutBack));
        mySequence = mySequence.Join(transform.DOMoveY(1, _eatTime / 2));

        mySequence = mySequence.Append(transform.DOScale(endScale, _eatTime / 2));
        mySequence = mySequence.Join(transform.DOMoveY(0, _eatTime / 2));

        StartCoroutine(MoveToEater(eater));
    }

    private IEnumerator MoveToEater(Transform eater)
    {
        while(true)
        {
            yield return null;
            float step = _speed * Time.deltaTime; // calculate distance to mov
            transform.position = Vector3.MoveTowards(transform.position, eater.transform.position, step);
        }
    }
}
