using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _stoppingDistance = 3f;
    [SerializeField] private float _speed = 1f;

    private Vector3 _currentTarget;
    private Rigidbody _rigidbody;
    private bool _isMove = false;
    
    public bool IsEndTarget { get; private set; }
    public bool IsMove => _isMove;
    public Vector3 GetTarget => _currentTarget;

    private void Start()
    {
        IsEndTarget = false;

        _rigidbody = GetComponent<Rigidbody>();
    }

    public void ChangeTarget(Vector3 target)
    {
        _currentTarget = target;
        IsEndTarget = false;
        _isMove = true;
    }

    public void Move()
    {
        if(_currentTarget != null && !IsEndTarget)
        {
            Vector3 newPosition = transform.position + (_currentTarget - transform.position).normalized * _speed * Time.deltaTime;
            _rigidbody.MovePosition(newPosition);

            if ((_currentTarget - transform.position).magnitude <= _stoppingDistance && !IsEndTarget)
            {
                IsEndTarget = true;
                _isMove = false;
            }
        }
    }
}
