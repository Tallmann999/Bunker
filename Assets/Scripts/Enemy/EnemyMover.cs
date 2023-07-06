using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class EnemyMover : MonoBehaviour
{
    public const string Move = "Move";

    [SerializeField] private Transform _pathTarget;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Animator _animator;

    private Transform[] _points;
    private int _currentPointIndex;
    private float _speed = 2f;
    private bool _isMoving = false;
    private bool _isRightVector=false;

    public bool IsRightVector => _isRightVector; 

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        InitPoints();
    }

    private void Update()
    {
        MoveToPoints();
        WalkAnimation();
    }

    public void ResetMover()
    {
        // —делать ћетод который будет стопорить движение персонажа, а потом будет производитьс€ выстрел
    }

    private void MoveToPoints()
    {
        Transform target = _points[_currentPointIndex];
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
        _isMoving = true;

        if (transform.position == target.position)
        {
            _spriteRenderer.flipX = true;
            _isRightVector = false;
            _currentPointIndex++;

            if (_currentPointIndex >= _points.Length)
            {
                _currentPointIndex = 0;
                _isRightVector = true;
                _spriteRenderer.flipX = false;
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

    private void WalkAnimation()
    {
        if (_isMoving)
        {
            _animator.SetBool(Move, true);
        }
    }
}
