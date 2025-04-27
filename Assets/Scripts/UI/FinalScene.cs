using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalScene : MonoBehaviour
{
    [SerializeField] private List<GameObject> stars;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private TMP_Text _result;
    [SerializeField] private GameObject nextLevel;
    [SerializeField] private GameObject reset;
    [SerializeField] private string _winText = "Уровень пройдет!";
    [SerializeField] private string _loseText = "Уровень провален!";
    [SerializeField] private string _nameNextScene;

    public void ViewStar(int value, float result)
    {
        for (int i = 0; i < value; i++)
        {
            stars[i].SetActive(true);
        }

        _result.text = "" + (int) result + " очков!";

        if (value == 0)
        {
            nextLevel.SetActive(false);
            _text.text = _loseText;
        }
        else
        {
            nextLevel.SetActive(true);
            _text.text = _winText;
        }
    }

    public void Restart()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(_nameNextScene);
    }
}
