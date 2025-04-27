using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text _maxTimeText;
    [SerializeField] private TMP_Text _currentTimeText;

    private int _maxTime;

    public void SetMaxTime(float time)
    {
        _maxTimeText.text = (int)time + "";
        _maxTime = (int)time;
    }

    public void SetCurrentTime(float time)
    {
        if (time > _maxTime)
            time = _maxTime;

        _currentTimeText.text = (int)time + "";
    }
}
