using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSlider : MonoBehaviour
{
    [SerializeField] private Image scoreImage;
    
    public void ViewScore(float value, float max)
    {
        scoreImage.fillAmount = (value > max ? max : value) / max;
    }
}
