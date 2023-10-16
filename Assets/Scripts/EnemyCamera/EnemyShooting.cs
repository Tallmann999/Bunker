using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyRotateDetector))]
public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private Weapon _currentWeapon;
    [SerializeField] private Player _player;
    [SerializeField] private EnemyRotateDetector _enemyRotateDetector;
    [SerializeField] private float _deleyAttack;
    [SerializeField] private float _shootingMovespeed;
    [SerializeField] private float _rotationModific;

    private Coroutine _activeCorutine = null;
    private float _lastAttackTime;

    private void OnEnable()
    {
        _enemyRotateDetector.OnShoot += Shooting;
    }

    private void OnDisable()
    {
        _enemyRotateDetector.OnShoot -= Shooting;
    }

    private void Start()
    {
        _enemyRotateDetector = GetComponent<EnemyRotateDetector>();
    }

    private void Update()
    {
        RotateToTarget(true);
    }

    private void Shooting(bool shoot)
    {
        if (_activeCorutine != null)
        {
            StopCoroutine(_activeCorutine);
        }

        _activeCorutine = StartCoroutine(Shoot(shoot));
    }

    private IEnumerator Shoot(bool shootStatus)
    {
        while (shootStatus)
        {
            if (_lastAttackTime <= 0)
            {
                _currentWeapon.Shoot();
                _lastAttackTime = _deleyAttack;
            }

            _lastAttackTime -= Time.deltaTime;

            yield return null;
        }
    }

    private void RotateToTarget(bool shootStatus)
    {
        if (shootStatus)
        {
            Vector3 vectorToTarget = _player.transform.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - _rotationModific;

            Quaternion angleTarget = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, angleTarget, Time.deltaTime * _shootingMovespeed);
        }
    }
}
