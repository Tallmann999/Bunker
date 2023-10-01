using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour,IDamagable
{
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _minHealth;
    //[SerializeField] private  

    private Weapon _currentWeapon;
    private bool _isCardFind = false;
    //private Card _exitCard;

    public Weapon CurrentWeapon => _currentWeapon;
    public int CurrentHealth { get; private set; }
    public event UnityAction<int> HealthChange;
    public bool CardAccessStatus =>_isCardFind;

    private void Start()
    {
        _currentWeapon = _weapons[0];
        CurrentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        CurrentHealth = Mathf.Clamp(CurrentHealth,_minHealth,_maxHealth);
        HealthChange?.Invoke(CurrentHealth);

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    public void TakeCard(Card exitcard)
    {
        _isCardFind = true;
        //_exitCard = exitcard;
    }

    public void Heal(int health)
    {
        CurrentHealth += health;
        CurrentHealth = Mathf.Clamp(CurrentHealth, _minHealth, _maxHealth);
        HealthChange?.Invoke(CurrentHealth);
    }

    public void TooggleActiveSpriteWeapon(bool toogle)
    {
        _currentWeapon.gameObject.SetActive(toogle);
    }

    private void Die()
    {
        Debug.Log("Персонаж мертв");

        Destroy(gameObject);
    }
}
