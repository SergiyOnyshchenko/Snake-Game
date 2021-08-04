using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class Fever : MonoBehaviour
{
    [SerializeField] private int _requiredJemCount;
    [SerializeField] private float _jemDelayTime;
    [SerializeField] private float _feverDuration;

    private IEnumerator _gemTimer;
    private int _gemCount = 0;

    private void Start() 
    {
        FoodManager.Instance.GemAded += AddGem;
    }

    private void OnDestroy()
    {
        FoodManager.Instance.GemAded -= AddGem;
    }

    private void AddGem(int count)
    {
        _gemCount++;

        if(_gemTimer != null)
            StopCoroutine(_gemTimer);

        _gemTimer = JemTimer();
        StartCoroutine("JemTimer");
    }

    private IEnumerator JemTimer()
    {
        if(_gemCount >= _requiredJemCount)
        {
            StartFever();
            StopCoroutine(_gemTimer);
        } 

        float jemTime = 0;
        while(jemTime < _jemDelayTime)
        {
            jemTime += Time.deltaTime;
            yield return null;
        }

        _gemCount = 0;
    }

    private void StartFever()
    {
        FoodManager.Instance.GemAded -= AddGem;

        var allFervers = FindObjectsOfType<MonoBehaviour>().OfType<IFever>();
        foreach (IFever fever in allFervers)
        {
            fever.StartFever();
        }

        StartCoroutine(EndFever());
    }

    private IEnumerator EndFever()
    {
        yield return new WaitForSeconds(_feverDuration);

        FoodManager.Instance.GemAded += AddGem;

        var allFervers = FindObjectsOfType<MonoBehaviour>().OfType<IFever>();
        foreach (IFever fever in allFervers)
        {
            fever.EndFever();
        }
    }
}
