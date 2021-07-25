using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SnakeEatingAnimation : MonoBehaviour
{
    private ISnakeSegments _snakeSegments;

    private void Start()
    {
        _snakeSegments = GetComponent<ISnakeSegments>();
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            StartCoroutine(Eating(1.5f));
        }
    }

    private IEnumerator Eating(float scaleMultiplier)
    {
        foreach (SnakeSegment segment in _snakeSegments.Segments)
        {
            yield return new WaitForSeconds(.1f);

            Transform currentSegment = segment.transform;
            Vector3 startScale = Vector3.one;
            Vector3 newScale = startScale * scaleMultiplier;

            currentSegment.DOScale(newScale, .15f).OnComplete(() => currentSegment.DOScale(startScale, .15f));
        }
    }
}
