using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCard : MonoBehaviour
{

    [SerializeField] private AudioSource _currentSound;
    [SerializeField] private AudioClip _pickupSound;

    private Coroutine _activeCoroutine = null;

    private void Start()
    {
        _currentSound = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            if (_activeCoroutine != null)
            {
                StopCoroutine(_activeCoroutine);
            }
            _activeCoroutine = StartCoroutine(PlayAndDie(player));

        }
    }

    private IEnumerator PlayAndDie(Player player)
    {
        bool _isPlay = true;

        while (_isPlay)
        {
            _currentSound.clip = _pickupSound;
            _currentSound.Play();
            player.TakeCard();
            yield return new WaitForSeconds(0.4f);
            _currentSound.Stop();
            Destroy(gameObject);
        }
    }
}
