using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private Player _target; // Впеменно цель врага это плеер
    public Player Target => _target;

    public  void TakeDamage(int damage)
    {
        _health-=damage;
    }

    private void Update()
    {
        if(_health<=0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }



}
