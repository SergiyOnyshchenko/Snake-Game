using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SnakeEatingAnimation : MonoBehaviour
{
    [SerializeField] private float _scaleMultiplier = 1.5f;

    private ISnakeSegments _snakeSegments;
    private Sequence _animation;

    private void Start()
    {
        _snakeSegments = GetComponent<ISnakeSegments>();
        FoodManager.Instance.ColorFoodAded += Eat;
        FoodManager.Instance.GemAded += Eat;
        _animation = DOTween.Sequence();
    }   

    private void OnDestroy()
    {
        FoodManager.Instance.ColorFoodAded -= Eat;
        FoodManager.Instance.GemAded -= Eat;

        _animation.Kill();
    }

    private void Eat(int amount)
    {
        StartCoroutine(EatingAnimation(_scaleMultiplier));
    }

    private IEnumerator EatingAnimation(float scaleMultiplier)
    {
        for (int i = 0; i < _snakeSegments.Segments.Count; i++)
        {
            yield return new WaitForSeconds(.1f);

            Transform currentSegment = _snakeSegments.Segments[i].transform;
            Vector3 startScale = Vector3.one;
            Vector3 newScale = startScale * scaleMultiplier;

            _animation.Append(currentSegment.DOScale(newScale, .15f).OnComplete(() => currentSegment.DOScale(startScale, .15f)));
        }
    }
}
