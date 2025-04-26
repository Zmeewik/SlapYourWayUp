using System.Collections.Generic;
using UnityEngine;

public class SerchObject : MonoBehaviour
{
    [SerializeField] private List<WorkPlace> _workPlaces;

    private void Start()
    {
        Transform[] children = GetComponentsInChildren<Transform>();

        foreach (Transform child in children)
            if (child.TryGetComponent(out WorkPlace wrk))
                _workPlaces.Add(wrk);
    }

    public Vector3 SearchWorkPlace(Vector3 place)
    {
        Vector3 minLen = Vector3.down;

        foreach (WorkPlace wrk in _workPlaces)
            if ((wrk.transform.position - place).magnitude < minLen.magnitude || minLen == Vector3.down)
                minLen = wrk.transform.position;

        return minLen;
    }
}
