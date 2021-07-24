using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeSpawner : MonoBehaviour
{
    [SerializeField] private SnakeSegment _bodyPartPrefab;
    [SerializeField] private int _segmentsCount;
    [SerializeField] private float _offsetBetweenSegments;
    [SerializeField] private float _spawnDelay;

    private Snake _snake;

    private void Start() 
    {
        _snake = GetComponent<Snake>();

        SnakeSegment head =  GetComponentInChildren<SnakeHead>();
        _snake.Segments.Add(head);

        StartCoroutine(CreateBodyParts());
    }

    private IEnumerator CreateBodyParts()
    {
        for (int i = 1; i <= _segmentsCount; i++)
        {
            yield return new WaitForSeconds(_spawnDelay);

            Vector3 spawnPosition = _snake.Segments[i - 1].transform.position + new Vector3(_offsetBetweenSegments, 0, 0);
            SnakeSegment newSegment = Instantiate(_bodyPartPrefab, spawnPosition, Quaternion.identity, transform);
            _snake.Segments.Add(newSegment);
        }
    }


}
