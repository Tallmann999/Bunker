using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class Player : MonoBehaviour, IDamagable
{
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private AudioSource _baseSource;
    [SerializeField] private AudioClip[] _hurt;
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _minHealth;

    private Weapon _currentWeapon;
    private Coroutine _activeCorutine = null;
    private WaitForSeconds _sleep = new WaitForSeconds(0.5f);
    private int _currentWeaponNumber = 0;
    private bool _isCardFind = false;
    private bool _isDie = false;
    private bool _isWin = false;

    public Weapon CurrentWeapon => _currentWeapon;
    public bool CardAccessStatus => _isCardFind;
    public int CurrentHealth { get; private set; }

    public event UnityAction<int> HealthChange;
    public event UnityAction<bool> Die;
    public event UnityAction<bool> Win;

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        _baseSource.clip = _hurt[Random.Range(0, _hurt.Length)];
        _baseSource.Play();

        CurrentHealth = Mathf.Clamp(CurrentHealth, _minHealth, _maxHealth);
        HealthChange?.Invoke(CurrentHealth);

        if (CurrentHealth <= 0)
        {
            _isDie = true;

            if (_activeCorutine != null)
            {
                StopCoroutine(_activeCorutine);
            }

            _activeCorutine = StartCoroutine(Died());
        }
    }

    public void TakeCard()
    {
        _isCardFind = true;
    }

    public void Heal(int health)
    {
        CurrentHealth += health;
        CurrentHealth = Mathf.Clamp(CurrentHealth, _minHealth, _maxHealth);
        HealthChange?.Invoke(CurrentHealth);
    }

    public void AddAmmoBox(int ammoCount)
    {
        _currentWeapon.AddAmmoBox(ammoCount);
    }

    public void TooggleActiveSpriteWeapon(bool toogle)
    {
        _currentWeapon.gameObject.SetActive(toogle);
    }

    private void Start()
    {
        _currentWeapon = _weapons[_currentWeaponNumber];
        CurrentHealth = _maxHealth;
        _baseSource = GetComponent<AudioSource>();
    }

    private void WinActivation()
    {
        _isWin = true;
        Win?.Invoke(_isWin);
        _currentWeapon?.gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Helicopter helicopter))
        {
            WinActivation();
        }
    }

    private IEnumerator Died()
    {
        Die?.Invoke(_isDie);
        _currentWeapon?.gameObject.SetActive(false);
        yield return _sleep;
        Time.timeScale = 0;
    }
}
