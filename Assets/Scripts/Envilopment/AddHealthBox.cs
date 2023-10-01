using System.Collections;
using UnityEngine;

public class AddHealthBox : MonoBehaviour
{
    [SerializeField] private AudioSource _healthSound;
    [SerializeField] private AudioClip _pickupSound;
    [SerializeField] private int _poitionHealthCount;

    private Coroutine _activeCoroutine;

    private void Start()
    {
        _healthSound = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
           if(_activeCoroutine != null)
            {
                StopCoroutine(_activeCoroutine);
            }
             _activeCoroutine= StartCoroutine(PlayAndDie(player));

        }
    }

    private IEnumerator PlayAndDie(Player player)
    {
        bool _isPlay = true;

        while (_isPlay)
        {
            _healthSound.clip = _pickupSound;
            _healthSound.Play();
            player.Heal(_poitionHealthCount);
            yield return new WaitForSeconds(0.4f);
            _healthSound.Stop();
            Destroy(gameObject);
        }
    }
}
