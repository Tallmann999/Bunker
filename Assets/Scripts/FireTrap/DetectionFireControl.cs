using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionFireControl : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private FireParticle _fireParticle;
    [SerializeField] private Collider2D _detectionCollider;

    private bool _particlrActivationToogle;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Player player))
        {
            player.TakeDamage(_damage);
        }
    }

    private void OnEnable()
    {
        _fireParticle.ParticlActivator += ToogleControl;
    }

    private void OnDisable()
    {
        _fireParticle.ParticlActivator -= ToogleControl;
    }

    private void ToogleControl(bool toggle)
    {
        _particlrActivationToogle = toggle;
        _detectionCollider.enabled = toggle;
    }
}
