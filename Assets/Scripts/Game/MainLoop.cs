using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainLoop : MonoBehaviour
{
    [Header("Level")]
    int currentLevel = -1;
    [SerializeField] List<string> startText;
    int strNum = 0;
    public float _maxScore;
    public float _maxTime;
    public GameObject level;
    public List<int> stars;

    bool started = false;


    [Header("System")]
    [SerializeField] private ScoreSlider _scoreView;
    [SerializeField] private float _currentScore;
    [SerializeField] private FinalScene _finalStr;
    [SerializeField] private Timer _timer;
    [SerializeField] GameObject TextObject;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] InputSctipt input;

    private float _currentTime = 0;

    public bool IsFinalGame { get; private set; }

    void Start()
    {
        SetLevel();
        Cursor.visible = false;
        var num = (int)(UnityEngine.Random.value * 3) + 1;
        PlayerPrefs.SetInt("Sound", 0);
        PlayerPrefs.SetInt("Music", 0);
        PlayerPrefs.Save();
        SoundManager.instance.Play("Music"+num);
        SoundManager.instance.Play("OfficeAmbient");
        text.text = startText[0];
        strNum = 1;
    }

    
    public void SkipText()
    {
        if(!started)
        {
            if(strNum > startText.Count - 1)
            {
                TextObject.SetActive(false);
                started = true;
            }
            else
            {
                text.text = startText[strNum];
                strNum++;
            }
        }
    }

    void Update()
    {
        if(!started)
            return;

        _scoreView.ViewScore(_currentScore, stars[2]);
        _currentTime += Time.deltaTime;

        if (_currentTime >= _maxTime && !IsFinalGame)
        {
            IsFinalGame = true;
            Final();
        }

        _timer.SetCurrentTime(_currentTime);
    }

    public void SetLevel()
    {
        currentLevel++;
        _timer.SetMaxTime(_maxTime);
    }

    public void ScoreAdd(float value)
    {
        if(started)
            _currentScore += value;
    }

    public float GetScore()
    {
        return _currentScore;
    }

    public void Final()
    {
        _finalStr.gameObject.SetActive(true);
        input.DisableRotation();
        Cursor.visible = true;

        int result = 0;

        for(int i = 0; i < stars.Count; i++)
            if (_currentScore >= stars[i])
                result++;

        _finalStr.ViewStar(result);
    }
}
