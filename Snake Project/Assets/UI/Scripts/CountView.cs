using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public abstract class CountView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _count;

    private RectTransform _rectTransform;

    private void Awake() 
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    protected void SetCount(int count)
    {
        _count.text = count.ToString();
        ScaleAnimation();
    }

    private void ScaleAnimation()
    { 
        _rectTransform.DOScale(_rectTransform.localScale * 1.1f, 0.1f).OnComplete(() => _rectTransform.DOScale(Vector3.one, 0.1f));
    }   
}
