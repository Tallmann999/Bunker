using System.Collections;
using UnityEngine;

public class CorrectorSound : MonoBehaviour
{
    [SerializeField] private AudioSource _baseSound;
    [SerializeField] private AudioClip _sounEffect;
    [SerializeField] private float _minVolum;
    [SerializeField] private float _maxVolum;

    private Coroutine _activeCorutine = null;
    private float _fadeSpeed = 0.3f;
    private float _targetVolume;

    public void IncreasesSound()
    {
        _targetVolume = _maxVolum;
        _baseSound.Play();

        if (_activeCorutine != null)
        {
            StopCoroutine(_activeCorutine);
        }

        _activeCorutine = StartCoroutine(ChangeVolume());
    }

    public void ReducesSound()
    {
        _targetVolume = _minVolum;

        if (_activeCorutine != null)
        {
            StopCoroutine(_activeCorutine);
        }

        _activeCorutine = StartCoroutine(ChangeVolume());
    }

    private IEnumerator ChangeVolume()
    {
        while (_baseSound.volume != _targetVolume)
        {
            _baseSound.volume = Mathf.MoveTowards(_baseSound.volume, _targetVolume, _fadeSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
