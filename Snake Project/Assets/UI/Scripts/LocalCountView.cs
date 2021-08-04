using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class LocalCountView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _countText;

    private RectTransform _transform;
    private int _currentCount = 0;
    private IEnumerator _reset;
    private Sequence sequence;

    private void Start() 
    {
        _transform = GetComponent<RectTransform>();

        FoodManager.Instance.ColorFoodAded += AddFood;
        FoodManager.Instance.GemAded += AddFood;

        SetAlpha(0);
    }

    private void OnDestroy() 
    {
        FoodManager.Instance.ColorFoodAded -= AddFood;
        FoodManager.Instance.GemAded -= AddFood;
    }

    private void AddFood(int amount)
    {       
        if(_reset != null)
            StopCoroutine(_reset);

        _reset = Reset();
        StartCoroutine(_reset);

        _currentCount++;
        SetCount(_currentCount);

        PlayAnimation();
    }

    private void PlayAnimation()
    {
        float time = 0.2f;

        if(sequence != null)
            sequence.Kill();

        SetAlpha(1);
        _transform.anchoredPosition = Vector2.zero;
        _transform.localScale = new Vector3(0, 0, 0);

        sequence = DOTween.Sequence();
        sequence.Append(_transform.DOScale(1, time/2).SetEase(Ease.OutBack));
        sequence.Join(_transform.DOAnchorPosY(1f, time).SetEase(Ease.OutBack));
        sequence.AppendInterval(time * 2);
        sequence.Append(_transform.DOScale(0, time).SetEase(Ease.InCubic));
        sequence.Join(_transform.DOAnchorPosY(-1f, time).SetEase(Ease.InCubic));
        sequence.Join(DOTween.To(() => _countText.color.a, x => SetAlpha(x), 0, time)); ;
    }

    private void SetCount(float count)
    {
        _countText.text = "+" + count.ToString();
    }

    private void SetAlpha(float alpha)
    {
        Color newColor = _countText.color;
        newColor.a = alpha;
        _countText.color = newColor;
    }

    private IEnumerator Reset()
    {
        yield return new WaitForSeconds(2f);
        _currentCount = 0;
        SetCount(_currentCount);
    }
    
}
