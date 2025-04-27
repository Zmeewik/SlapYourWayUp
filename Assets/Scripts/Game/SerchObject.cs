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

    public WorkPlace SearchWorkPlace(Vector3 place)
    {
        WorkPlace minLen = null;

        foreach (WorkPlace wrk in _workPlaces)
            if ((minLen == null || (wrk.transform.position - place).magnitude < minLen.transform.position.magnitude) && !wrk.IsBusy)
                minLen = wrk;

        return minLen;
    }
}
