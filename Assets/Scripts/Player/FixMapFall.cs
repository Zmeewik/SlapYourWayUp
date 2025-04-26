using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixMapFall : MonoBehaviour
{
    void FixedUpdate()
    {
        if(transform.position.y < -30)
            transform.position = Vector3.zero;
        else if(transform.position.y > 100)
            transform.position = Vector3.zero;
    }
}
