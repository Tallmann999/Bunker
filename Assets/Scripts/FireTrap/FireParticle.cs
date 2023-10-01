using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FireParticle : MonoBehaviour
{
    [SerializeField] private ParticleSystem _fireParticles;
    [SerializeField] private float _activationDelay = 3f;
    [SerializeField] private float _deactivationDelay = 1f;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _fireSound;
    

    private Coroutine _activeCoroutine;
    public event UnityAction<bool> ParticlActivator;
    private bool _activation;
    // написать будевую переменную на работу цикла в корутине
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        if (_activeCoroutine !=null)
        {
            StopCoroutine(ActivateParticles());
        }

        _activeCoroutine=StartCoroutine(ActivateParticles());
    }

    private IEnumerator ActivateParticles()
    {
        while (true)
        {
            _fireParticles.Play();
            _audioSource.clip = _fireSound;
            _audioSource.Play();
            _activation = true;
            ParticlActivator?. Invoke(_activation);
            yield return new WaitForSeconds(_activationDelay);
            _fireParticles.Stop();
            _activation = false;
            ParticlActivator?.Invoke(_activation);
            yield return new WaitForSeconds(_deactivationDelay);
        }
    }
}
