using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour, IFever
{
    private ICollide _snakeCollide;

    private void Start() 
    {
        Init();
    }

    private void Init()
    {
        gameObject.layer = 10;
        _snakeCollide = new KillCollide();
    }

    public void StartFever()
    {
        gameObject.layer = 9;
        gameObject.AddComponent<SimpleFood>();
        _snakeCollide = new NonCollide();
    }

    public void EndFever()
    {
        if (gameObject.TryGetComponent(out SimpleFood food))
        {
            Destroy(food);
        }
        Init();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent == null)
            return;

        if (other.transform.parent.TryGetComponent(out Snake snake))
        {
            _snakeCollide.CollideWithOpponent(snake.gameObject);
        }
    }
}
