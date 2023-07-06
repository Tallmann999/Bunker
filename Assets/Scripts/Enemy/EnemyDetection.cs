using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Enemy))]
public class EnemyDetection : MonoBehaviour
{
    //[SerializeField] private EnemyMover _enemyMover;
    [SerializeField] private Transform _enemy;
    [SerializeField] private Transform _detectorRay;
    [SerializeField] private float _detectionDistance = 5f;
    [SerializeField] private LayerMask _detectionLayer;
    [SerializeField] private Animator _animator;

    private void Update()
    {
        Vector2 direction = _enemy.localScale.x > 0 ? Vector2.right : Vector2.left;
        Ray2D ray = new Ray2D(_detectorRay.position, direction);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, _detectionDistance, _detectionLayer);

        if (hit.collider != null)
        {
            //_animator.Play("Shoot");
        }

        Debug.DrawRay(ray.origin, ray.direction * _detectionDistance, Color.red);
    }
}
