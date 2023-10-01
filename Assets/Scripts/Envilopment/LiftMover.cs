using UnityEngine;

public class LiftMover : MonoBehaviour
{
    [SerializeField] private SwitchButton _statusSwitch;
    [SerializeField] private Transform _pathTarget;
    [SerializeField] private SoundEffectZone _soundEffectZone;

    private Transform[] _points;
    private int _currentPointIndex;

    private void Start()
    {
        _soundEffectZone = GetComponent<SoundEffectZone>();
        _soundEffectZone.enabled = false;
        InitPoints();
    }

    private void Update()
    {
        if (_statusSwitch.ButtonOn)
        {
            Move();
        }
    }

    private void Move()
    {
        _soundEffectZone.enabled = true;

        Transform target = _points[_currentPointIndex];
        transform.position = Vector3.MoveTowards(transform.position, target.position, 0.5f * Time.deltaTime);

        if (transform.position == target.position)
        {
            _currentPointIndex++;

            if (_currentPointIndex >= _points.Length)
            {
                _currentPointIndex = 0;
            }

        }
    }

    private void InitPoints()
    {
        _points = new Transform[_pathTarget.childCount];

        for (int i = 0; i < _pathTarget.childCount; i++)
        {
            _points[i] = _pathTarget.GetChild(i);
        }
    }
}
