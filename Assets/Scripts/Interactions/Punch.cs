using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class Punch : MonoBehaviour
{
    //Layer mask
    [SerializeField] private LayerMask punchThings;
    [SerializeField] private Transform cameraHolder;
    [SerializeField] private float maxPushForce;
    [SerializeField] private float minPushForce;
    [SerializeField] private float chargeTimeMax;
    [SerializeField] private Slider forceBar;
    [SerializeField] private float punchDistance;
    [SerializeField] Image fillImage;
    [SerializeField] CoffeeThrow coffeScr;
    [SerializeField] Animator anim;
    float currentForce = 0;
    float currentProgress = 0;
    bool startedCharge = false;



    //Main punch handle
    public void PunchHandle(float time, bool hit)
    {
        if(hit)
        {
            PunchAnything(currentForce, currentProgress);
            currentProgress = 0;
            UpdateForceBar();
        }
        BuildUpPunchForce(time);
    }

    //Punch force build up
    private void BuildUpPunchForce(float time)
    {

        if(!startedCharge)
        {
            anim.Play("Up");
            Invoke("ChargeAnim", 0.5f);
        }

        //Handle time
        if(time > chargeTimeMax)
            time = chargeTimeMax;
        
        time = time / chargeTimeMax;
        //Add force
        currentForce = Math.Clamp(time, 0, 1);
        if(currentForce < 0.1f)
            currentForce = 0.1f;
        //Add progress
        currentProgress = Math.Clamp(time, 0, 1);
        UpdateForceBar();
    }

    private void ChargeAnim()
    {
        anim.Play("Charge");
    }

    //Punch something
    private void PunchAnything(float force, float progress)
    {
        //Raycast
        Ray ray = new Ray(cameraHolder.position, cameraHolder.forward);
        RaycastHit hit;
        Debug.DrawRay(cameraHolder.position, cameraHolder.forward * punchDistance, Color.red, 0.1f);
        if (Physics.Raycast(ray, out hit, punchDistance, punchThings))
        {
            //Found rigidbody: push something
            Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
            print(hit.collider.name);
            if (rb != null)
            {
                Vector3 forceDirection = hit.point - cameraHolder.position;
                forceDirection = forceDirection.normalized;
                //Push
                rb.AddForce(forceDirection * (minPushForce + (maxPushForce - minPushForce) * force), ForceMode.Impulse); // сила толчка 5f
                //Hit sound
                if(force < 0.5)
                {
                    Particles.instance.PlayUIParticle("slap");
                    SoundManager.instance.Play("Slap");
                    anim.Play("Slap");
                }
                else
                {
                    Particles.instance.PlayUIParticle("strongSlap");
                    SoundManager.instance.Play("StrongSlap");
                    anim.Play("Slap");
                }
            }
            
            //Activate
            var activatable = hit.collider.GetComponent<IInteractable>();
            if (activatable != null)
            {

                var col = GetComponent<Collider>();
                if(col != null)
                    activatable.Activate(col, progress);
                print(hit.collider.tag);
                if(hit.collider.tag == "Motivation")
                {
                    print(hit.collider.tag);
                    coffeScr.AddLoad();
                }

                //Hit sound
                if(force < 0.5)
                {
                    Particles.instance.PlayUIParticle("slap");
                    SoundManager.instance.Play("Slap");
                }
                else
                {
                    Particles.instance.PlayUIParticle("strongSlap");
                    SoundManager.instance.Play("StrongSlap");
                }
            }
        }
    }

    private void UpdateForceBar()
    {
        forceBar.value = currentProgress;
    }

        private void ChargeAnimIdle()
    {
        anim.Play("Idle");
    }
}
