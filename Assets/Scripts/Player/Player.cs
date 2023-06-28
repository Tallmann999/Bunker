using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapons;
    
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _minHealth;
    private int _currentHealth;
    private Weapon _currentWeapon;

    public Weapon CurrentWeapon => _currentWeapon;


    private void Start()
    {
        _currentWeapon = _weapons[0];
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {

    }

    public void AddHealth(int health)
    {

    }

    public  void ToggleActiveSpriteWeapon(bool toogle)
    {
        _currentWeapon.gameObject.SetActive(toogle);
    }
}
