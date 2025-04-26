using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Mechanism))]
public class MotivationBar : MonoBehaviour, IInteractable
{
    
    float motivation;
    [Header("Motivation")]
    [SerializeField] float maxMotivation;
    [SerializeField] Slider motivationBar;
    [SerializeField] float minMotivationAdd;
    [SerializeField] float maxMotivationAdd;
    [SerializeField] Image fillImage;
    [Header("Decrease")]
    [SerializeField] float timeNoChange;
    [SerializeField] float decreaseSpeed;

    public void Activate(Collider goal, float force)
    {
        motivation += Math.Clamp(force, minMotivationAdd, maxMotivationAdd);
        print("punch: " + motivation);
    }

    void Update()
    {
        UpdateBar();
    }

    void FixedUpdate()
    {
        DecreaseMotivation();
    }

    //Update UI Bar
    public void UpdateBar()
    {
        if (fillImage != null)
        {
            fillImage.fillAmount = motivation / maxMotivation;
        }
    }

    public void DecreaseMotivation()
    {

    }
}
