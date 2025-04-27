using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeThrow : MonoBehaviour
{
    [SerializeField] int maxLoads;
    GameObject cam;
    [SerializeField] GameObject coffee;
    [SerializeField] float throwForce;
    int currentLoads = 0;

    void Start()
    {
        cam = Camera.main.gameObject;
    }

    // Add loads to coffee counter
    public void AddLoad()
    {
        currentLoads += 1;
        print(currentLoads);
    }

    //Throw coffe at someone
    public void ThrowCoffee()
    {
        if(currentLoads >= maxLoads)
        {
            
            currentLoads = 0;
            var obj = Instantiate(coffee, cam.transform.position + cam.transform.forward * 2f, Quaternion.identity);
            var rb = obj.GetComponent<Rigidbody>();
            print(cam.transform.forward);
            rb.AddForce(throwForce * cam.transform.forward, ForceMode.Impulse);
            rb.AddTorque(new Vector3(Random.value, Random.value, Random.value) * 50f);
        }
    }

}
