using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _stoppingDistance = 3f;

    private Vector3 _currentTarget;
    private NavMeshAgent _meshAgent;
    private Rigidbody _rigidbody;
    
    public bool IsEndTarget { get; private set; }

    private void Start()
    {
        IsEndTarget = false;

        _rigidbody = GetComponent<Rigidbody>();

        _meshAgent = GetComponent<NavMeshAgent>();
        _meshAgent.stoppingDistance = _stoppingDistance;
    }

    public void ChangeTarget(Vector3 target)
    {
        _currentTarget = target;
        IsEndTarget = false;
    }

    public void Move()
    {
        if(_currentTarget != null && !IsEndTarget)
        {
            _meshAgent.SetDestination(_currentTarget);

            if ((_currentTarget - transform.position).magnitude <= _stoppingDistance)
            {
                IsEndTarget = true;
            }
        }
    }
}
