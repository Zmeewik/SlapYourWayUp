using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLoop : MonoBehaviour
{
    [SerializeField] private float _maxScore;
    [SerializeField] private ScoreSlider _scoreView;

    [SerializeField] private float _currentScore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _scoreView.ViewScore(_currentScore, _maxScore);
    }
}
