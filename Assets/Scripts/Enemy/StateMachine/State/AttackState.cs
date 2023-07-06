using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AttackState : State
{
    [SerializeField] private DistansTransition distansTransition;
    [SerializeField] private float _deleyAttack;
    [SerializeField] private EnemyBullet Prefab;
    [SerializeField] private Transform ShootPointPosition;
  
    //[SerializeField] private Weapon _weapon;
    //[SerializeField] private SpriteRenderer _spriteRenderer;
    private float _lastAttackTime;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();

        //_spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (_lastAttackTime<=0)
        {
            Attack(Target);
            _lastAttackTime= _deleyAttack;
        }

        _lastAttackTime -=Time.deltaTime;

        // прекращать стрелять и возвращаться к ходьбе если дистанция большая
    }

    private void Attack(Player target)
    {
        EnemyBullet bullet = Instantiate(Prefab, ShootPointPosition.position, ShootPointPosition.rotation);
        _animator.Play("Attack");

        if (distansTransition.RotateStatus)
        {
            bullet.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            // Если луч смотрит влево, поворачиваем пулю влево
            bullet.transform.localScale = new Vector3(1f, 1f, 1f);
        }

        //target.TakeDamage();сделать событие которое будет работать за попадание

    }
}
