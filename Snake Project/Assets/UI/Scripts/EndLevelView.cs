using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndLevelView : MonoBehaviour
{
    [SerializeField] private string _levelFinishedText;
    [SerializeField] private string _gameOverText;

    private TextMeshProUGUI _title;

    private void Start() 
    {
        _title = GetComponentInChildren<TextMeshProUGUI>();

        GameManager.Instance.LevelFinished += ShowLevelFinished;
        GameManager.Instance.PlayerLost += ShowGameOver;

        gameObject.SetActive(false);
    }

    private void OnDestroy() 
    {
        GameManager.Instance.LevelFinished -= ShowLevelFinished;
        GameManager.Instance.PlayerLost -= ShowGameOver;
    }

    private void ShowLevelFinished()
    {
        _title.text = _levelFinishedText;
        gameObject.SetActive(true);
    }

    private void ShowGameOver()
    {
        _title.text = _gameOverText;
        gameObject.SetActive(true);
    }
}
