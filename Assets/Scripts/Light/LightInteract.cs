using UnityEngine;

public class LightInteract : MonoBehaviour
{
    [SerializeField] private Light _activeLight;
    [SerializeField] private ParticleSystem _explosionEffect;
    [SerializeField] private AudioClip _lampExsplosionSound;
    [SerializeField] private AudioSource _lampSound;

    private bool _isPlay = false;

    private void Start()
    {
        _explosionEffect = GetComponent<ParticleSystem>();
        _lampSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Bullet bullet) && !_isPlay)
        {
            _explosionEffect.Play();
            _activeLight.intensity = 0;
            _isPlay = true;
            _lampSound.clip = _lampExsplosionSound;
            _lampSound.Play();
        }
    }
}
