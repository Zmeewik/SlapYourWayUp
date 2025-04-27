using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinalScene : MonoBehaviour
{
    [SerializeField] private List<GameObject> stars;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private TMP_Text _result;
    [SerializeField] private string _winText = "MOLODEC!";
    [SerializeField] private string _loseText = "NE_MOLODEC!";

    public void ViewStar(int value)
    {
        for (int i = 0; i < value; i++)
        {
            stars[i].SetActive(true);
        }

        _result.text = "" + value;

        if (value == 0)
            _text.text = _loseText;
        else
            _text.text = _winText;
    }
}
