using UnityEngine;

public class WorkPlace : MonoBehaviour
{
    [SerializeField] private float _scoreAdd;
    [SerializeField] private float _chanceBreake;
    [SerializeField] private float _timeLoopBreake;

    public bool IsLifeObject { get; private set; }
    public float ScoreAddPlace => _scoreAdd;

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
}
