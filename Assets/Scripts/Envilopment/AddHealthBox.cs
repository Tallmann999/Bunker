using System.Collections;
using UnityEngine;

public class AddHealthBox : MonoBehaviour, IInteractable
{
    [SerializeField] private AudioSource _baseSound;
    [SerializeField] private AudioClip _pickupSound;
    [SerializeField] private int _poitionHealthCount;

    private Coroutine _activeCoroutine = null;
    private WaitForSeconds _sleep = new WaitForSeconds(0.4f);

    public IEnumerator PlaySoundAndDie(Player player)
    {
        bool _isPlay = true;

        while (_isPlay)
        {
            _baseSound.clip = _pickupSound;
            _baseSound.Play();
            player.Heal(_poitionHealthCount);
            yield return _sleep;
            _baseSound.Stop();
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _baseSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            if (_activeCoroutine != null)
            {
                StopCoroutine(_activeCoroutine);
            }

            _activeCoroutine = StartCoroutine(PlaySoundAndDie(player));
        }
    }

}
