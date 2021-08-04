using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ShowUIAnimation : MonoBehaviour
{
    [SerializeField] private float _duration;

    private RectTransform _transform;
    private Sequence _animation;
    
    private void OnEnable() 
    {
        if(_transform == null)
            _transform = GetComponent<RectTransform>();

        _transform.localScale = Vector3.zero;

        _animation = DOTween.Sequence();
        _animation.Append(_transform.DOScale(1, _duration).SetEase(Ease.OutElastic));
    }

    private void OnDestroy() 
    {
        _animation.Kill();
    }
}
