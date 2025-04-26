using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour, IInteractable
{

    [Header("Button")]
    [SerializeField] float buttonUpTime;
    [SerializeField] Transform movingButton;
    [SerializeField] GameObject activation;
    [SerializeField] float minY;
    [SerializeField] float maxY;
    float buttonCurrentTime;

    void FixedUpdate()
    {
        buttonCurrentTime += Time.deltaTime;
        if(buttonCurrentTime > buttonUpTime)
            buttonCurrentTime = buttonUpTime;
        var y = Math.Clamp(buttonCurrentTime/buttonUpTime, minY, maxY);
        movingButton.localPosition = new Vector3(0, y, 0);
    }

    public void Activate(Collider sender, float force)
    {
        movingButton.localPosition = new Vector3(0, minY, 0);
        buttonCurrentTime = 0;
        var interactable = activation.GetComponent<IInteractable>();
        if(interactable != null)
        {
            interactable.Activate(sender, force);
        }
    }


}
