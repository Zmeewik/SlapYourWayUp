using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    [SerializeField] List<GameObject> particles;
    [SerializeField] GameObject uiPoint;
    static public Particles instance;
    GameObject uiObj;

    private void Start()
    {
        instance = this;
    }

    public void PlayParticles(Vector3 position, string type)
    {
        int num = 0;
        switch(type)
        {
            case "coffee":
                num = 0;
            break;
            case "inspiraton":
                num = 1;
            break;
        }
        var obj = Instantiate(particles[num], position, Quaternion.identity);
        Destroy(obj, 1f);
    }

    public void PlayUIParticle(string type)
    {
        int num = 0;
        switch(type)
        {
            case "slap":
                num = 2;
            break;
            case "strongSlap":
                num = 3;
            break;
        }
        var obj = Instantiate(particles[num], uiPoint.transform);
        uiObj = obj;
        Destroy(obj, 1f);
    }

    private void FixedUpdate()
    {
        if(uiObj != null)
            uiObj.transform.position = uiPoint.transform.position;
    }
}
