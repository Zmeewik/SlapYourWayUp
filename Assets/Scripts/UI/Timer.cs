using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text _currentTimeText;

    public void SetCurrentTime(float time)
    {
        if (time < 0)
            time = 0;

        _currentTimeText.text = (int)time + "";
    }
}
