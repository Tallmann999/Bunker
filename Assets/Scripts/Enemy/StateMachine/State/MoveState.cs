using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoveState : State
{
    public const string Move = "Move";

    [SerializeField] private float _speed;
    [SerializeField] private Transform _pathTarget;
    [SerializeField] private Animator _animator;

    private Transform[] _points;
    private int _currentPointIndex;
    private bool _isMoving = false;
    private bool IsRight;
    public event UnityAction<bool> RightMove;

    private void Start()
    {
        _animator = GetComponent<Animator>();

        InitPoints();
    }

    void Update()
    {
        MoveToPoints();
        WalkAnimation();
    }

    private void MoveToPoints()
    {
        Transform target = _points[_currentPointIndex];
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
        _isMoving = true;

        if (transform.position == target.position)
        {
            transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1, 1, 1));
            IsRight = true;
            _currentPointIndex++;

            if (_currentPointIndex >= _points.Length)
            {
                transform.localScale = Vector3.Scale(transform.localScale, new Vector3(1, 1, 1));
                _currentPointIndex = 0;
                IsRight = false;
            }

            RightMove?.Invoke(IsRight);
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

    private void WalkAnimation()
    {
        if (_isMoving)
        {
            _animator.SetBool(Move, true);
        }
    }
}
