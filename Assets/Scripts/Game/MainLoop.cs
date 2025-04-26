using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLoop : MonoBehaviour
{
    [Header("Level")]
    [SerializeField] private float _maxScore;
    [SerializeField] private float _maxTime;

    [Header("System")]
    [SerializeField] private ScoreSlider _scoreView;

    [SerializeField] private float _currentScore;

    private float _currentTime = 0;

    public bool IsFinalGame { get; private set; }

    void Update()
    {
        _scoreView.ViewScore(_currentScore, _maxScore);
        _currentTime += Time.deltaTime;

        if (_currentTime >= _maxTime)
            IsFinalGame = true;
    }

    public void ScoreAdd(float value)
    {
        _currentScore += value;
    }

    public float GetScore()
    {
        return _currentScore;
    }
}
