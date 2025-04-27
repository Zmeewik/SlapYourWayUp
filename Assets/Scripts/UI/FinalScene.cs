using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScene : MonoBehaviour
{
    [SerializeField] private List<GameObject> stars;

    public void ViewStar(int value)
    {
        for (int i = 0; i < value; i++)
        {
            stars[i].SetActive(true);
        }
    }
}
