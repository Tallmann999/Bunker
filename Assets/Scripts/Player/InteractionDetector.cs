using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionDetector : MonoBehaviour
{
    [SerializeField] private PlayerMover _mover;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Ladder ladder))
        {
            _mover.LadderMove(RigidbodyType2D.Kinematic,true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ladder ladder))
        {
            _mover.LadderMove(RigidbodyType2D.Dynamic,false);
        }
    }
}
