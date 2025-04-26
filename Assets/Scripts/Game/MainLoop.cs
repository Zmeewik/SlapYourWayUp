using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLoop : MonoBehaviour
{
    [Header("Level")]
    [SerializeField] List<Level> Levels;
    int currentLevel = 0;
    [Serializable]
    struct Level
    {
        public float _maxScore;
        public float _maxTime;
        public GameObject level;
    }


    [Header("System")]
    [SerializeField] private ScoreSlider _scoreView;
    [SerializeField] private float _currentScore;

    private float _currentTime = 0;

    public bool IsFinalGame { get; private set; }

    void Start()
    {
        var num = (int)(UnityEngine.Random.value * 3) + 1;
        print(num);
        SoundManager.instance.Play("Music"+num);
    }

    void Update()
    {
        _scoreView.ViewScore(_currentScore, Levels[currentLevel]._maxScore);
        _currentTime += Time.deltaTime;

        if (_currentTime >= Levels[currentLevel]._maxTime)
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
