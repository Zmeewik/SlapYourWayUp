using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BilboardRotate : MonoBehaviour
{

    private Transform cam;
    [SerializeField] Transform attachObject;
    [SerializeField] float offset;

    void Start()
    {
        cam = Camera.main.transform;
    }

    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
        transform.position = attachObject.position + Vector3.up * offset;
    }

}
