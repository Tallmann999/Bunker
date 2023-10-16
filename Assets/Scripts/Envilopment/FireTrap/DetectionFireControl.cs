using UnityEngine;

public class DetectionFireControl : MonoBehaviour
{
    [SerializeField] private FireParticle _fireParticle;
    [SerializeField] private Collider2D _detectionCollider;
    [SerializeField] private int _damage;

    private void OnEnable()
    {
        _fireParticle.ParticlActivator += ToogleControl;
    }

    private void OnDisable()
    {
        _fireParticle.ParticlActivator -= ToogleControl;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.TakeDamage(_damage);
        }
    }

    private void ToogleControl(bool toggle)
    {
        _detectionCollider.enabled = toggle;
    }
}
