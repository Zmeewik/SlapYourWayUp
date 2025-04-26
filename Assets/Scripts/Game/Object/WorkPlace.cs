using UnityEngine;

public class WorkPlace : MonoBehaviour
{
    [SerializeField] private float _scoreAdd;
    [SerializeField] private float _chanceBreake;
    [SerializeField] private float _timeLoopBreake;

    private bool _isBusy = false;
    private baseNPC _currentWorker;

    public bool IsLifeObject { get; private set; }
    public float ScoreAddPlace => _scoreAdd;
    public bool IsBusy => _isBusy;
    public baseNPC CurrentWorker => _currentWorker;

    private float _time = 0;

    private void Start()
    {
        IsLifeObject = true;
    }

    private void Update()
    {
        if (IsLifeObject)
        {
            if (_time >= _timeLoopBreake)
            {
                int random = Random.Range(1, 100);

                if (random <= _chanceBreake)
                {
                    IsLifeObject = false;
                    Debug.Log("Breake");
                }

                _time = 0;
            }
            else
            {
                _time += Time.deltaTime;
            }
        }
    }

    public void Deactivate()
    {
        _isBusy = false;
        _currentWorker = null;
    }

    public void SetWorker(baseNPC npc)
    {
        _currentWorker = npc;
        _isBusy = true;
    }
}
