using System;
using System.Collections.Generic;
using UnityEngine;

public class SerchObject : MonoBehaviour
{
    [SerializeField] private List<workEmploee> _workPlaces;
    [Serializable]
    struct workEmploee
    {
        public WorkPlace workPlace;
        public GameObject worker;
    }
    

    public WorkPlace SearchWorkPlace(GameObject worker)
    {
        WorkPlace minLen = null;

        foreach (workEmploee wrk in _workPlaces)
            if (worker == wrk.worker)
                minLen = wrk.workPlace;
        return minLen;
    }
}
