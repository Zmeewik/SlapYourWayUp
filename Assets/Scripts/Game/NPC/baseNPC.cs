using System;
using UnityEngine;

public class baseNPC : MonoBehaviour
{
    [SerializeField] private float _timeUpdateScore;
    [SerializeField] private MainLoop _mainLoop;

    private WorkPlace _currentWorkPlace = null;
    private float _time = 0;

    public bool IsWork
    {
        get
        {
            return _currentWorkPlace != null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out WorkPlace workPlace) && _currentWorkPlace == null)
        {
            _currentWorkPlace = workPlace;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out WorkPlace workPlace) && _currentWorkPlace == workPlace)
        {
            _currentWorkPlace = null;
        }
    }

    private void Update()
    {
        if (IsWork)
        {
            if (_time >= _timeUpdateScore)
            {
                _mainLoop.ScoreAdd(_currentWorkPlace.ScoreAddPlace);
                _time = 0;
                Debug.Log("Score+: " + _currentWorkPlace.ScoreAddPlace);
            }
            else
            {
                _time += Time.deltaTime;
            }
        }
    }
}
