using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Mechanism))]
public class RepairBar : MonoBehaviour, IInteractable
{
    
    float repair;
    [Header("Repair")]
    [SerializeField] float maxRepair;
    [SerializeField] Slider repairBar;
    [SerializeField] float minRepairAdd;
    [SerializeField] float maxRepairAdd;
    [Header("Decrease")]
    [SerializeField] float timeNoChange;
    [SerializeField] float decreaseSpeed;
    float currenTime = 0;
    [SerializeField] public bool IsFixed;


    //Break object
    public void Break()
    {
        repair = 0;
        transform.parent.GetChild(1).gameObject.SetActive(true);
        IsFixed = false;
    }

    public void Repair()
    {
        transform.parent.GetChild(1).gameObject.SetActive(false);
        IsFixed = true;
    }

    public void Activate(Collider goal, float force)
    {
        repair += Math.Clamp(force, minRepairAdd, maxRepairAdd);
        if(repair >= 1)
            Repair();
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
        repairBar.value = repair / maxRepair;
    }

    public void DecreaseMotivation()
    {
        if(currenTime < 0)
            repair -= decreaseSpeed;
        else
            currenTime -= Time.deltaTime;

        //Limit repair down
        if(repair <= 0)
            repair = 0;
    }
}
