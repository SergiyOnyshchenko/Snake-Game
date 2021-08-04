using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public abstract class Food : MonoBehaviour, IDeath
{
    [SerializeField] private float _eatingDuration = 0.35f;
    [SerializeField] private float _speed = 10f;

    private IEdible _edible;

    public IEdible Edible { get => _edible; set => _edible = value; }
    public event Action IsDied;

    private void Awake() 
    {
        gameObject.layer = 9;
    }
    
    public void StartEat(Eater eater)
    {
        gameObject.layer = 2;

        PlayEatingAnimation(_eatingDuration);
        StartCoroutine(MoveToEater(eater.EatPoint, _speed));
    }

    protected abstract void FinishEat();

    public void Die()
    {
        IsDied?.Invoke();
        Destroy(gameObject);
    }

    private IEnumerator MoveToEater(Transform target, float speed)
    {
        while (true)
        {
            yield return null;
            float step = speed * Time.deltaTime;
            transform.Translate(Vector3.Normalize(target.position - transform.position) * step);
        }
    }

    private void PlayEatingAnimation(float duration)
    {
        Vector3 startScale = transform.localScale;
        Vector3 endScale = Vector3.zero;

        Sequence sequence = DOTween.Sequence();

        sequence.Append(transform.DOScale(startScale * 0.9f, duration / 3).SetEase(Ease.OutBack));
        sequence.Append(transform.DOScale(startScale * 1.25f, duration / 3).SetEase(Ease.OutBack));
        sequence.Join(transform.DOMoveY(1.5f, duration / 3));

        sequence.Append(transform.DOScale(endScale, duration / 3));
        sequence.Join(transform.DOMoveY(0, duration / 3));

        sequence.InsertCallback(duration, () => {
            FinishEat();
            Die(); 
            });
    }
}
