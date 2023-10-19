using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class FireParticle : MonoBehaviour
{
    [SerializeField] private ParticleSystem _fireParticles;
    [SerializeField] private AudioSource _baseSound;
    [SerializeField] private AudioClip _fireSound;
    [SerializeField] private float _deactivationDelay = 1f;
    [SerializeField] private float _activationDelay = 3f;

    private Coroutine _activeCoroutine = null;
    private bool _activation = true;

    public event UnityAction<bool> ParticlActivator;

    private void Start()
    {
        _baseSound = GetComponent<AudioSource>();

        if (_activeCoroutine != null)
        {
            StopCoroutine(_activeCoroutine);
        }

        _activeCoroutine = StartCoroutine(ActivateParticles());
    }

    private IEnumerator ActivateParticles()
    {
        bool activeCicle = true;

        while (activeCicle)
        {
            _fireParticles.Play();
            _baseSound.clip = _fireSound;
            _baseSound.Play();
            _activation = true;
            ParticlActivator?.Invoke(_activation);
            yield return new WaitForSeconds(_activationDelay);

            _fireParticles.Stop();
            _activation = false;
            ParticlActivator?.Invoke(_activation);
            yield return new WaitForSeconds(_deactivationDelay);
        }
    }
}
