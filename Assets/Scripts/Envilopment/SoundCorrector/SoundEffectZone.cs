using UnityEngine;

public class SoundEffectZone : MonoBehaviour
{
    [SerializeField] private CorrectorSound _correctorSound;

    private void Start()
    {
        _correctorSound = GetComponent<CorrectorSound>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _correctorSound.IncreasesSound();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _correctorSound.ReducesSound();
        }
    }
}
