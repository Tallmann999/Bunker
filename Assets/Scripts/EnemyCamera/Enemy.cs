using System.Collections;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private GameObject _detectorObject;
    [SerializeField] private ParticleSystem _explosionEffect;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _explosionSound;

    private bool _isDead;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _explosionEffect = GetComponentInChildren<ParticleSystem>();
    }

    public void TakeDamage(int damage)
    {
        if (!_isDead)
        {
            _health -= damage;

            if (_health <= 0)
            {
                StartCoroutine(Die());
                _isDead = true;
            }
        }
    }

    private IEnumerator Die()
    {
        _audioSource.clip = _explosionSound;
        _explosionEffect.Play();
        _audioSource.Play();
        yield return new WaitForSeconds(0.3f);
        _explosionEffect.Stop();
        //yield return new WaitForSeconds(0.1f);

        _detectorObject.SetActive(false);
    }
}