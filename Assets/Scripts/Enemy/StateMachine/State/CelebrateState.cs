using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CelebrateState : State
{
    private Animator _animator;

   private  void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _animator.Play("Celebration");
    }

    private void OnDisable()
    {
        _animator.StopPlayback();
    }
}
