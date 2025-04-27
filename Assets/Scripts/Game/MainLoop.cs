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
        public List<int> stars;
    }


    [Header("System")]
    [SerializeField] private ScoreSlider _scoreView;
    [SerializeField] private float _currentScore;
    [SerializeField] private FinalScene _finalStr;

    private float _currentTime = 0;

    public bool IsFinalGame { get; private set; }

    void Start()
    {
        var num = (int)(UnityEngine.Random.value * 3) + 1;
        PlayerPrefs.SetInt("Sound", 0);
        PlayerPrefs.SetInt("Music", 0);
        PlayerPrefs.Save();
        SoundManager.instance.Play("Music"+num);
        SoundManager.instance.Play("OfficeAmbient");
    }

    void Update()
    {
        _scoreView.ViewScore(_currentScore, Levels[currentLevel]._maxScore);
        _currentTime += Time.deltaTime;

        if (_currentTime >= Levels[currentLevel]._maxTime && !IsFinalGame)
        {
            IsFinalGame = true;
            Final();
        }
    }

    public void ScoreAdd(float value)
    {
        _currentScore += value;
    }

    public float GetScore()
    {
        return _currentScore;
    }

    public void Final()
    {
        _finalStr.gameObject.SetActive(true);

        int result = 0;

        for(int i = 0; i < Levels[currentLevel].stars.Count; i++)
            if (_currentScore >= Levels[currentLevel].stars[i])
                result++;

        _finalStr.ViewStar(result);
    }
}
