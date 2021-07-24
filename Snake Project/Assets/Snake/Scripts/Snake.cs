using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Snake : MonoBehaviour
{
    private List<SnakeSegment> _segments = new List<SnakeSegment>();

    public List<SnakeSegment> Segments { get => _segments;}

    private void Start() 
    {

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
        for (int i = 1; i < _segments.Count; i++)
        {
            yield return new WaitForSeconds(.1f);

            Transform currentSegment = _segments[i].transform;
            Vector3 startScale = Vector3.one;
            Vector3 newScale = startScale * scaleMultiplier;

            currentSegment.DOScale(newScale, .15f).OnComplete(() => currentSegment.DOScale(startScale, .15f)); 
            //currentSegment.DOScale(newScale, .1f);
        }
    }
    


}
