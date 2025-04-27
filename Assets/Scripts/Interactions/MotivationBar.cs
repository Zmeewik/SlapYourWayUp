using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    [Header("Decrease")]
    [SerializeField] float timeNoChange;
    float currenTime = 0;
    [SerializeField] float decreaseSpeed;

    [Header("Phrases")]
    [SerializeField] float phraseChance;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] GameObject textObject;
    [SerializeField] List<string> phrases;
    [SerializeField] float phraseTime;
    float currentPhraseTime = 0;

    public float CurrentMotivation => motivation;

    public void Activate(Collider goal, float force)
    {
        motivation += Math.Clamp(force, minMotivationAdd, maxMotivationAdd);
        var chance = UnityEngine.Random.value;
        if(chance < phraseChance)
        {
            var phrase = (int) (UnityEngine.Random.value * phrases.Count);
            text.text = phrases[phrase];
            textObject.SetActive(true);
            currentPhraseTime = phraseTime;
        }
        if(motivation >= maxMotivation)
        {
            motivation = maxMotivation;
            currenTime = timeNoChange;
        }
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
        motivationBar.value = motivation / maxMotivation;
    }

    public void DecreaseMotivation()
    {
        //Decreasing motivation after some time passed
        if(currenTime < 0)
            motivation -= decreaseSpeed;
        else
            currenTime -= Time.deltaTime;

        //Limit motivation down
        if(motivation <= 0)
            motivation = 0;


        //Limit phrase time
        if(currentPhraseTime <= 0)
            EndPhrase();
        else
            currentPhraseTime -= Time.deltaTime;
    }



    private void EndPhrase()
    {   
        textObject.SetActive(false);
    }

    //If gets coffee object break it, make effect, sound and motivation charge
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Coffee")
        {
            motivation = maxMotivation;
            currenTime = timeNoChange;
            Destroy(collision.gameObject);
            print("coffeed");
        }
    }
}
