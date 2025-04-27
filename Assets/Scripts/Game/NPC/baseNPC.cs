using System.IO;
using UnityEngine;

public class baseNPC : MonoBehaviour
{
    [SerializeField] private float _timeUpdateScore;
    [SerializeField] private MainLoop _mainLoop;
    [SerializeField] private SerchObject _serchObject;
    [SerializeField] private float timeInactive;
    [SerializeField] private Animator anim;
    private float curTime;
    bool stunned = false;
    bool going = false;

    private WorkPlace _currentWorkPlace = null;
    private float _time = 0;

    private Movement _movement;
    private MotivationBar _motivation;

    public bool IsWork
    {
        get
        {
            return _currentWorkPlace != null && _movement.IsEndTarget;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out WorkPlace workPlace) && _currentWorkPlace == null)
        {
            if(workPlace.CurrentWorker == this)
            {
                _currentWorkPlace = workPlace;
                anim.Play("CharacterArmature|Punch");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out WorkPlace workPlace) && _currentWorkPlace == workPlace)
        {
            workPlace.Deactivate();
            _currentWorkPlace = null;
        }
    }
    
    private void Start()
    {
        _movement = GetComponent<Movement>();
        _motivation = GetComponent<MotivationBar>();
    }

    private void Update()
    {
        if(!stunned)
        {
            if (IsWork)
            {
                if (_time >= _timeUpdateScore)
                {
                    _mainLoop.ScoreAdd(_currentWorkPlace.ScoreAddPlace * _motivation.CurrentMotivation);
                    _time = 0;
                }
                else
                {
                    _time += Time.deltaTime;
                }
            }
            else if(!IsWork)
            {

                if(_currentWorkPlace == null && !_movement.IsMove)
                {
                    WorkPlace newPlace = _serchObject.SearchWorkPlace(transform.position);

                    if(newPlace != null)
                    {
                        newPlace.SetWorker(this);
                        _movement.ChangeTarget(newPlace.transform.position);
                    } 
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if(!stunned)
        {
            if(!going)
            {
                anim.Play("CharacterArmature|Run");
                going = true;
            }
            if (!_movement.IsEndTarget)
            {
                _movement.Move();
                _movement.RotateToTarget();
            }
        }
    }


    public void Stun()
    {
        stunned = true;
        going = false;
        anim.Play("CharacterArmature|Death");
        Invoke("UnStun", timeInactive);
    }

    public void UnStun()
    {
        stunned = false;
        anim.Play("CharacterArmature|StandUp");
    }
}
