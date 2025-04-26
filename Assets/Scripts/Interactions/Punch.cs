using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour
{
    //Layer mask
    [SerializeField] private LayerMask punchThings;
    [SerializeField] private Transform cameraHolder;
    [SerializeField] private float minPushForce;
    [SerializeField] private float maxPushForce;
    [SerializeField] private float chargeTimeMax;



    //Main punch handle
    public void PunchHandle(float time, bool hit)
    {
        if(hit)
        {
            
        }
        BuildUpPunchForce(time);
    }

    //Punch force build up
    private void BuildUpPunchForce(float time)
    {
        if(time > chargeTimeMax)
            time = chargeTimeMax;
        
    }

    //Punch something
    private void PunchAnything(float force)
    {
        //Raycast
        Ray ray = new Ray(cameraHolder.position, cameraHolder.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 2f, punchThings))
        {
            //Found rigidbody: push something
            Rigidbody rb = hit.collider.attachedRigidbody;
            if (rb != null)
            {
                Vector3 forceDirection = hit.point - cameraHolder.position;
                forceDirection = forceDirection.normalized;
                //Push
                rb.AddForce(forceDirection * 5f, ForceMode.Impulse); // сила толчка 5f
            }
            
            //Activate
            var activatable = hit.collider.GetComponent<IInteractable>();
            if (activatable != null)
            {
                var col = GetComponent<Collider>();
                if(col != null)
                    activatable.Activate(col);
            }
        }

    }
}
