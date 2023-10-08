using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour,IDamagable
{
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _minHealth;
    //[SerializeField] private Canvas _mainCanvas;

    private Weapon _currentWeapon;
    private int _currentWeaponNumber = 0;
    private bool _isCardFind = false;
    

    public Weapon CurrentWeapon => _currentWeapon;
    public bool IsDie => _isDie;
    private bool _isDie = false;
    public bool IsWin => _isWin;
    private bool _isWin = false;
    public int CurrentHealth { get; private set; }

    public event UnityAction<int> HealthChange;
    public event UnityAction<bool> Die;
    public event UnityAction<bool> Win;

    public bool CardAccessStatus =>_isCardFind;

    private void Start()
    {
        ChangeWeapon(_weapons[_currentWeaponNumber]);
        CurrentHealth = _maxHealth;
    }

    public void PreviesWeapon()
    {
        // Сделать чтоб по кругу менялось текущее оружие из текущего списка.
       // Настроить смену оружия, чтоб предыдущее отключалось оружие
        if (_currentWeaponNumber == 0)
        {
            _currentWeaponNumber = _weapons.Count - 1;
        }
        else
        {
            _currentWeaponNumber--;
        }

        ChangeWeapon(_weapons[_currentWeaponNumber]);

    }


        public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        CurrentHealth = Mathf.Clamp(CurrentHealth,_minHealth,_maxHealth);
        HealthChange?.Invoke(CurrentHealth);

        if (CurrentHealth <= 0)
        {
            _isDie = true;
            StartCoroutine(Died());
        }

        StopCoroutine(Died());
    }

    public void TakeCard()
    {
        _isCardFind = true;
    }

    private  void WinActivation()
    {
        _isWin = true;
        Win?.Invoke(_isWin);
        _currentWeapon?.gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Helicopter helicopter))
        {
            WinActivation();
        }
    }

    private void ChangeWeapon(Weapon weapon)
    {
        _currentWeapon = weapon;
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

    private IEnumerator Died()
    {
        Die?.Invoke(_isDie);
        
       _currentWeapon?.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0;
    }
}
