using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(ParticleSystem))]
public class Enemy : MonoBehaviour, IDamagable
{
    [SerializeField] private GameObject _detectorObject;
    [SerializeField] private ParticleSystem _explosionEffect;
    [SerializeField] private AudioSource _baseSound;
    [SerializeField] private AudioClip _explosionSound;
    [SerializeField] private int _health;

    private bool _isDead;
    private WaitForSeconds _sleep =  new WaitForSeconds(0.3f);
    private Coroutine _activeCorutine = null;

    public void TakeDamage(int damage)
    {
        if (!_isDead)
        {
            _health -= damage;

            if (_health <= 0)
            {
                if (_activeCorutine != null)
                {
                    StopCoroutine(_activeCorutine);
                }

                _activeCorutine = StartCoroutine(ExsplotionAndDie());
                _isDead = true;
            }
        }
    }

    private void Start()
    {
        _baseSound = GetComponent<AudioSource>();
        _explosionEffect = GetComponentInChildren<ParticleSystem>();
    }

    private IEnumerator ExsplotionAndDie()
    {
        _baseSound.clip = _explosionSound;
        _explosionEffect.Play();
        _baseSound.Play();
        yield return _sleep;
        _explosionEffect.Stop();
        _detectorObject.SetActive(false);
    }
}